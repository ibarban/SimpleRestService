long requestCount = 0;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/health", (HttpContext context) => {
    if (requestCount < 500)
    {
        context.Response.StatusCode = 200; // OK
    }
    else
    {
        context.Response.StatusCode = 400; // Bad Request
    }
});

app.MapGet("/simpleRequest", (HttpContext context) => {
    requestCount++;
});

app.Run();
