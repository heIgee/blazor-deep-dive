﻿namespace ServerManagement.Models;

public class CitiesRepository
{
    private static readonly List<string> cities =
    [
        "Tokyo",
        "Berlin",
        "London",
        "Sydney",
        "Paris",
        "Singapore",
        "Shanghai"
    ];

    public static List<string> Cities => cities;
}
