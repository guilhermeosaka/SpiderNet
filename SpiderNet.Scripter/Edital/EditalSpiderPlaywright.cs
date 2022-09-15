using Microsoft.Playwright;
using SpiderNet.Core.Engine.PlaywrightCore;

namespace SpiderNet.Scripter.Edital;

public class ParamEditalPlaywright
{
    
}

public class EditalSpiderPlaywright : SpiderPlaywright
{
    private ParamEditalPlaywright _param;
    
    public EditalSpiderPlaywright(ParamEditalPlaywright param, ConfigPlaywright config) : base(config)
    {
        _param = param;
    }

    public void ExtractOuterFields()
    {
    }

    protected override async Task RunAsync(IBrowserContext context)
    {
        await RunAsync(context, _param);
    }

    protected Task RunAsync(IBrowserContext context, ParamEditalPlaywright param)
    {
        throw new NotImplementedException();
    }
}