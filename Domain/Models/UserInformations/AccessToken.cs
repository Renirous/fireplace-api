﻿using FireplaceApi.Domain.Attributes;
using System;

namespace FireplaceApi.Domain.Models;

public class AccessToken : BaseModel
{
    public ulong UserId { get; set; }
    [Sensitive]
    public string Value { get; set; }
    public User User { get; set; }

    public AccessToken(ulong id, ulong userId, string value,
        DateTime creationDate, DateTime? modifiedDate = null,
        User user = null) : base(id, creationDate, modifiedDate)
    {
        UserId = userId;
        Value = value ?? throw new ArgumentNullException(nameof(value));
        User = user;
    }

    public AccessToken PureCopy() => new(Id, UserId, Value,
        CreationDate, ModifiedDate);

    public void RemoveLoopReferencing()
    {
        User = User?.PureCopy();
    }
}
