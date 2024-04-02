var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Endpoint endPoint = context.GetEndpoint();
    await next(context);
});

//enable routing
app.UseRouting();

app.Use(async (context, next) =>
{
    Endpoint endPoint = context.GetEndpoint();
    await next(context);
});

//creating endpoints
app.UseEndpoints(endpoints =>
{
    //add your endpoints here
    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map 1");
    });

    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map 2");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Home {context.Request.Path}");
});
app.Run();
