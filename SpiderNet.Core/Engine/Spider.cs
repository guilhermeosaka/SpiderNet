namespace SpiderNet.Core.Models;

public abstract class Spider
{
    private IParam _param;

    public Spider(IParam param)
    {
        _param = param;
    }
    
    protected abstract Task ConfigureAsync();
    
    public async Task StartAsync()
    {
        await ConfigureAsync();
        await RunAsync();
        await DisposeAsync();
    }

    protected abstract Task RunAsync();

    protected abstract Task DisposeAsync();
}