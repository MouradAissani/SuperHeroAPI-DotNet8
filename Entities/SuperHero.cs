﻿namespace SuperHeroAPI_DotNet8.Entities;

public class SuperHero
{
    public string Id { get; set; }
    public required string Name { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Place { get; set; } = string.Empty;
}