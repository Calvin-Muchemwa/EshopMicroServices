var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    bool scalf = true;
    
    return "Hello World!";
});

app.Run();
