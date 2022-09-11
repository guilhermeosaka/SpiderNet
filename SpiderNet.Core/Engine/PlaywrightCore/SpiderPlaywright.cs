using Microsoft.Playwright;

namespace SpiderNet.Core.Models.PlaywrightCore;

public abstract class SpiderPlaywright : Spider
{
    
    
    public string Name { get; set; }
    public bool Headless { get; set; }
    public int SlowMotion { get; set; }

    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    
    async Task ConfigureAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new() {
            Headless = Headless,
            SlowMo = SlowMotion
        });
        _context = await _browser.NewContextAsync();
    }

    async Task RunAsync() => await RunAsync(_context!);

    protected abstract Task RunAsync(IBrowserContext context);

    protected override async Task DisposeAsync()
    {
        if (_context != null) await _context.DisposeAsync();
        if (_browser != null) await _browser.DisposeAsync();
        _playwright?.Dispose();
    }
}