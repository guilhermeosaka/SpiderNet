using Xunit;

namespace SpiderNet.Utility.Tests;

public class CompilerTests
{
    [Fact]
    public async void TestSimpleStatements()
    {
        var compiler = new Compiler();
        
        var result = await compiler.CompileAsync<string>(@"
            using System;
            using Microsoft.Playwright;

            public string TestMethod()
            {
                return ""Hello World"";
            }

            return TestMethod();
        ");
        Assert.Equal("Hello World", result);
    }
}