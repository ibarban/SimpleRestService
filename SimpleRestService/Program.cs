long requestCount = 0;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/helath", (HttpContext context) => {
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
