// <copyright file="UserRepository.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        var result = this.dbContext.Users.Add(user);
        await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
        return result.Entity;
    }

    public async Task<int> DeleteAsync(UserId id)
    {
        var filteredData = await this.dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

        if (filteredData != null)
        {
            this.dbContext.Users.Remove(filteredData);
        }

        return await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await this.dbContext.Users.ToListAsync().ConfigureAwait(false);
    }

    public async Task<User?> GetAsync(UserId id)
    {
        return await this.dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<int> UpdateAsync(User user)
    {
        this.dbContext.Users.Update(user);
        return await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}
