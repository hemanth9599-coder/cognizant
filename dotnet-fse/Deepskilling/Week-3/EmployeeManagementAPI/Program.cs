using System.Text;
using EmployeeManagementAPI.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

IdentityModelEventSource.ShowPII = true;

var builder = WebApplication.CreateBuilder(args);

// JWT Configuration
string securityKey = "mysuperdupersecretkey12345678901234";

var symmetricSecurityKey = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(securityKey));

// Add services
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = symmetricSecurityKey,

        ValidateIssuer = true,
        ValidIssuer = "mySystem",

        ValidateAudience = true,
        ValidAudience = "myUsers",

        ValidateLifetime = true,

        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("=========== JWT AUTHENTICATION FAILED ===========");
            Console.WriteLine(context.Exception.ToString());
            Console.WriteLine("=================================================");
            Console.ResetColor();

            return Task.CompletedTask;
        },

        OnTokenValidated = context =>
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=========== JWT TOKEN VALID ===========");
            Console.WriteLine("User Successfully Authenticated");
            Console.WriteLine("=======================================");
            Console.ResetColor();

            return Task.CompletedTask;
        },

        OnChallenge = context =>
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("=========== JWT CHALLENGE ===========");
            Console.WriteLine($"Error: {context.Error}");
            Console.WriteLine($"Description: {context.ErrorDescription}");
            Console.WriteLine("=====================================");
            Console.ResetColor();

            return Task.CompletedTask;
        }
    };
});

// Authorization
builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee Management API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter JWT Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();