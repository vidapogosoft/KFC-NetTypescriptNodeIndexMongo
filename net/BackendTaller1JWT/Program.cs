using BackendTaller1.Interfaces;
using BackendTaller1.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = "Demo token Apikey Example para backend";

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(

        x => { x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    ).AddJwtBearer(

        x =>
        {
            x.SaveToken = true;
            x.RequireHttpsMetadata = false;

            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                ValidateIssuerSigningKey = true,

                ValidateAudience = false,
                ValidateIssuer = false
            };

        }
    
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>

    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Auth",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
            },Array.Empty<string>()
        }
        });

    });

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IJwt>(new SJwt(key));
builder.Services.AddSingleton<IOrders, SOrders>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
