// id

using Microsoft.Playwright;

namespace SpiderNet.Core.Engine.PlaywrightCore;

public abstract class SpiderPlaywright : Spider<BrowserPlaywright>
{
    private ConfigPlaywright _config;
    
    public SpiderPlaywright(ConfigPlaywright config)
    {
        _config = config;
    }
    
    private IPlaywright? _playwright;
    private Microsoft.Playwright.IBrowser? _browserPW;
    private IBrowserContext? _context;

    protected override async Task ConfigureAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browserPW = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = _config.Headless,
            SlowMo = _config.SlowMotion
        });
        _context = await _browserPW.NewContextAsync();
    }

    protected override async Task RunAsync() => await RunAsync(_context!);

    protected abstract Task RunAsync(IBrowserContext context);

    protected override async Task DisposeAsync()
    {
        if (_context != null) await _context.DisposeAsync();
        if (_browserPW != null) await _browserPW.DisposeAsync();
        _playwright?.Dispose();
    }
}