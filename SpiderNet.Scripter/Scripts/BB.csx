using System;
using Microsoft.Playwright;

var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new() {
    Headless = false,
    // SlowMo = 2000
});
var page = await browser.NewPageAsync();

var ids = new string[] 
{
    "942489", "936451", "926101"
};

foreach (var id in ids)
{
    await page.GotoAsync("https://www.licitacoes-e.com.br/aop/pesquisar-licitacao.aop?opcao=preencherPesquisarIdentificador");
    await page.Locator("#numeroLicitacao").FillAsync(id);
    await page.ClickAsync("input[name=pesquisar]");
    await page.SolveRecaptchaAsync();
    await page.ScreenshotAsync(new PageScreenshotOptions { Path = $"screenshot-{id}.png" });

    await page.WaitForTimeoutAsync(5000);
}