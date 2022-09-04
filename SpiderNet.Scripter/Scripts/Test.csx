using System;
using Microsoft.Playwright;

var playwright = await Playwright.CreateAsync();
var browser = await playwright.Chromium.LaunchAsync(new() {
    Headless = false,
    // SlowMo = 2000
});

Console.WriteLine("TESTING");