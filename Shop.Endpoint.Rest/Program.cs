using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shop.Application;
using Shop.Endpoint.Rest.ActionFilters;
using Shop.Endpoint.Rest.MinimalApis;
using Shop.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ParamValidatorAttribute>();
});
builder.Services.AddScoped<ParamValidatorAttribute>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Shop API", Version = "v1" });

    // Define the OAuth2.0 scheme that's in use (i.e., Implicit Flow)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    builder.Services.AddEndpointsApiExplorer();

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});

builder.Services.ResolveApplication();
var keyvalues = new Dictionary<string, string>();
keyvalues.Add("ConnectionString", builder.Configuration.GetConnectionString("ShopDB"));
keyvalues.Add("RedisConnectionStrig", builder.Configuration.GetConnectionString("Redis"));
keyvalues.Add("Key", builder.Configuration.GetSection("Jwt").GetSection("Key").Value);
keyvalues.Add("Issuer", builder.Configuration.GetSection("Jwt").GetSection("Issuer").Value);
keyvalues.Add("Audience", builder.Configuration.GetSection("Jwt").GetSection("Audience").Value);
keyvalues.Add("SmsProvider", builder.Configuration.GetSection("SmsProvider").Value);

builder.Services.ResolveInfrastructure(keyvalues);
var app = builder.Build();


app.UseCors("CORS");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();
app.MapControllers();


app.Run();
