using HtmlAgilityPack;

namespace SpiderNet.Core.Engine;

public abstract class Spider<T> where T : IBrowser, new()
{
    private IBrowser? _browser;

    public Spider() {
        _browser = new T();
    }

    protected void SetBrowser<T>() where T : IBrowser, new()
    {
        _browser = new T();
    }

    private Task InitAsync()
    {
        throw new NotImplementedException();
    }

    protected abstract Task ConfigureAsync();
    
    public async Task StartAsync()
    {
        await InitAsync();
        await ConfigureAsync();
        await RunAsync();
        await DisposeAsync();
    }

    protected abstract Task RunAsync();

    protected abstract Task DisposeAsync();

    protected async Task<HtmlDocument> GetHtmlAsync(string url) 
    {
        var web = new HtmlWeb();
        return await web.LoadFromWebAsync(url);
    }
}