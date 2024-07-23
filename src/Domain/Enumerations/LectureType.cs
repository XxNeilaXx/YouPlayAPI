// <copyright file="LectureType.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

namespace Domain.Enumerations;

/// <summary>
/// Lecture type enumeration.
/// </summary>
public sealed class LectureType : BaseEnumeration
{
    /// <summary>
    /// Foundation.
    /// </summary>
    public static readonly LectureType Foundation = new(1, "Foundation");

    /// <summary>
    /// FullSong.
    /// </summary>
    public static readonly LectureType FullSong = new(2, "FullSong");

    private LectureType(int id, string name)
        : base(id, name)
    {
    }
}
