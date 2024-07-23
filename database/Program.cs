using System.Text;
using DbUp;
using DbUp.Engine;
using DbUp.ScriptProviders;
using DbUp.Support;

namespace Migrations;

internal static class Program
{
    internal static void Main(string[] args)
    {
        if (args.Length <= 0)
        {
            throw new ArgumentNullException(nameof(args));
        }

        try
        {
            var connectionString = args[0];

            var scriptsDirectory = Path.Combine(Environment.CurrentDirectory, "Scripts");
            if (Directory.Exists(scriptsDirectory))
            {
                var scriptsSubDirectories = Directory.GetDirectories(scriptsDirectory);
                foreach (var scriptsSubDirectory in scriptsSubDirectories)
                {
                    Console.WriteLine(scriptsSubDirectory);
                    var fileEntries = Directory.GetFiles(scriptsSubDirectory);
                    foreach (var filePath in fileEntries)
                    {
                        Console.WriteLine(filePath);
                    }
                }
            }

            var options = new FileSystemScriptOptions
            {
                IncludeSubDirectories = true,
                Extensions = new[] { "*.sql" },
                Encoding = Encoding.UTF8,
            };

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .JournalToPostgresqlTable("YouPlay", "DbUpSchemaVersions")
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "1_PreDeployment"), options, new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 0 })
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "2_Deployment/1_Tables"), options, new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 1 })
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "2_Deployment/2_Indexes"), options, new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 2 })
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "2_Deployment/3_Procedures"), options, new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 3 })
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "2_Deployment/4_Views"), options, new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 4 })
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "2_Deployment/5_Data"), options, new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 5 })
                .WithScriptsFromFileSystem(Path.Combine(scriptsDirectory, "3_PostDeployment"), options, new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 6 })
                .WithTransaction()
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{result.Successful}: {result.Error}");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result.Successful);
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            throw;
        }
    }
}
