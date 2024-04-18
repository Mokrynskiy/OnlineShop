using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using OnlineShop.Gateway.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.AddAppAuthentication();
builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();
