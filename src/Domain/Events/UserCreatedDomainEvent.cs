// <copyright file="UserCreatedDomainEvent.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using MediatR;

namespace Domain.Events;

/// <summary>
/// Event dispatched when an user entity is created.
/// </summary>
/// <param name="userId"></param>
/// <param name="name"></param>
/// <param name="email"></param>
public record UserCreatedDomainEvent(
        string userId,
        string name,
        string email)
    : INotification
{
}
