using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shop.Application;
using Shop.Endpoint.Rest.MinimalApis;
using Shop.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Pappa´s API", Version = "v1" });

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

builder.Services.ResolveApplication();
var keyvalues = new Dictionary<string, string>();
keyvalues.Add("ConnectionString", builder.Configuration.GetConnectionString("ShopDB"));
keyvalues.Add("RedisConnectionStrig", builder.Configuration.GetConnectionString("Redis"));
keyvalues.Add("Key", builder.Configuration.GetSection("Jwt").GetSection("Key").Value);
keyvalues.Add("Issuer", builder.Configuration.GetSection("Jwt").GetSection("Issuer").Value);
keyvalues.Add("Audience", builder.Configuration.GetSection("Jwt").GetSection("Audience").Value);
keyvalues.Add("SmsProvider", builder.Configuration.GetSection("SmsProvider").Value);

builder.Services.ResolveInfrastructure(keyvalues);
builder.Services.AddCors(x=>x.AddPolicy("cors",x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.AddOtpMinimalApi();


app.UseAuthorization();
app.UseCors("cors");
app.MapControllers();


app.Run();
