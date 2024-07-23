// <copyright file="IUserRepository.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

/// <summary>
/// IUserRepository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Creates an user entity.
    /// </summary>
    /// <param name="user">The user data.</param>
    /// <returns>The user entity.</returns>
    Task<User> CreateAsync(User user);

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns>All the users in the repository.</returns>
    Task<IEnumerable<User>> GetAllAsync();

    /// <summary>
    /// Gets one user.
    /// </summary>
    /// <param name="id">The unique user identifier.</param>
    /// <returns>The user.</returns>
    Task<User?> GetAsync(UserId id);

    /// <summary>
    /// Updates one user.
    /// </summary>
    /// <param name="user">The user entity with the values to update.</param>
    /// <returns>The updated user entity.</returns>
    Task<int> UpdateAsync(User user);

    /// <summary>
    /// Deletes one user by id.
    /// </summary>
    /// <param name="id">The id of the user to be deleted.</param>
    /// <returns>The number of users deleted.</returns>
    Task<int> DeleteAsync(UserId id);
}
