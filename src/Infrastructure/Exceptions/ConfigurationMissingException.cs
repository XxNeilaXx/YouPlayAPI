// <copyright file="ConfigurationMissingException.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using System.Configuration;
using System.Text;

namespace Infrastructure.Exceptions;

internal sealed class ConfigurationMissingException : ConfigurationErrorsException
{
    private static readonly CompositeFormat DefaultMessage = CompositeFormat.Parse("{0} is not defined");

    public ConfigurationMissingException(string key)
       : base(string.Format(null, DefaultMessage, key))
    {
    }

    public ConfigurationMissingException(string key, Exception inner)
        : base(string.Format(null, DefaultMessage, key), inner)
    {
    }

    private ConfigurationMissingException()
    {
    }
}
