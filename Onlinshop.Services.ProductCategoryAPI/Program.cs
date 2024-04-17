using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineShop.Services.ProductCategoryAPI;
using OnlineShop.Services.ProductCategoryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        //Type = SecuritySchemeType.OAuth2,
        //Flows = new OpenApiOAuthFlows
        //{
        //    Implicit = new OpenApiOAuthFlow
        //    {
        //        AuthorizationUrl = new Uri("https://youauthsrv.com/auth/realms/your-realm/protocol/openid-connect/auth"),
        //    }
        //},
        //In = ParameterLocation.Header,
        //Scheme = JwtBearerDefaults.AuthenticationScheme,
                
        Name = "Authorization",
        Description = "JWT token must be provided",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
ApplyMigration();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (db.Database.GetPendingMigrations().Any())
        {
            db.Database.Migrate();
        }
    }
}
