using System.Threading.Tasks;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/api/echo/{name}", (string name) =>
{
    app.Logger.LogDebug($"echo {name}");
    return name;
});

app.MapGet("/api/lazy/{name}", async (string name) =>
{
    var rnd = new Random();
    int number = rnd.Next(10,1000);
    app.Logger.LogDebug($"delay {number}");
    await Task.Delay(number);
    return $"{name} - {number}";
});

app.Run();