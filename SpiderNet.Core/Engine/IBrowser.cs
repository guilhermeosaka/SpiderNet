using HtmlAgilityPack;

namespace SpiderNet.Core.Engine;

public interface IBrowser
{
    Task GoToAsync();
    Task ClickAsync();
    Task<HtmlDocument> GetHtmlAsync();
    Task DisposeAsync();
}