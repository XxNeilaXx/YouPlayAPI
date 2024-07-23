// <copyright file="Lecture.cs" company="XxNeilaXx">
// Copyright (c) XxNeilaXx. All rights reserved.
// </copyright>

using Domain.Enumerations;

namespace Domain.Entities;

/// <summary>
/// Lecture.
/// </summary>
public class Lecture
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Lecture"/> class.
    /// </summary>
    /// <param name="url">The external YouTube URL to the lecture.</param>
    /// <param name="name">The YouTube title of the lecture.</param>
    /// <param name="type">The <see cref="LectureType"/> type.</param>
    public Lecture(Uri url, string name, LectureType type)
    {
        this.Url = url;
        this.Name = name;
        this.Type = type;
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="Lecture"/> class from being created.
    /// </summary>
    private Lecture()
    {
        this.Url = new Uri(string.Empty);
        this.Name = string.Empty;
        this.Type = LectureType.Foundation;
    }

    /// <summary>
    /// Gets the external YouTube URL to the lecture.
    /// </summary>
    public Uri Url { get; init; }

    /// <summary>
    /// Gets the YouTube title of the lecture.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the <see cref="LectureType"/> type.
    /// </summary>
    public LectureType Type { get; init; }
}
