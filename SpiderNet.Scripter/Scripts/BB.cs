using Microsoft.Playwright;

namespace SpiderNet.Scripter.Scripts
{
    public class BB : IRunnable
    {
        public async Task Run()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() {
                Headless = false,
                // SlowMo = 2000
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.google.com.br");
            Console.WriteLine("test1");
            await page.WaitForTimeoutAsync(5000);
            
            Console.WriteLine("test");

            var bb2 = new BB2();
            bb2.PrintSomethingElse();
        }
    }

    public class BB2
    {
        public void PrintSomethingElse()
        {
            Console.WriteLine("Something else");
        }
    }
}