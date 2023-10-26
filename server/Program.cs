using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<MyHub>("/chat");

app.Run();

class MyHub : Hub
{
    public async IAsyncEnumerable<DateTime> Streaming(CancellationToken cct)
    {
        yield return DateTime.Now;
        await Task.Delay(1000, cct);
    }
}