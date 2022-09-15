using HtmlAgilityPack;

namespace SpiderNet.Core.Engine.PlaywrightCore;

public class BrowserPlaywright : IBrowser
{
    public Task ClickAsync()
    {
        throw new NotImplementedException();
    }

    public Task<HtmlDocument> GetHtmlAsync()
    {
        throw new NotImplementedException();
    }

    public Task GoToAsync()
    {
        throw new NotImplementedException();
    }
}