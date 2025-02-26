using System.Text;
using LgymApp.Api.Endpoints.Auth;
using LgymApp.Api.Extensions;
using LgymApp.Api.Interfaces;
using LgymApp.Api.Middlewares;
using LgymApp.Application.Interfaces;
using LgymApp.Application.Options;
using LgymApp.Application.Services;
using LgymApp.DataAccess;
using LgymApp.DataAccess.Interceptors;
using LgymApp.DataAccess.Interfaces;
using LgymApp.DataAccess.Repositories;
using LgymApp.Domain.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(nameof(AuthOptions)));

builder.Services.AddSingleton<AuditableObjectsSaveChangesInterceptor>();

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .AddInterceptors(
            sp.GetRequiredService<AuditableObjectsSaveChangesInterceptor>()
        );
});

//builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddServices();
builder.Services.AddEndpoints();

#region Auth

var authOptions = builder.Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Secret));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = authOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = key,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization();

#endregion

var app = builder.Build();

var routeGroupBuilder = app.MapGroup("api");
app.UseEndpoints(routeGroupBuilder);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "LgymApp.Api v1");
    });
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalTransactionHandlerMiddleware>();
//app.UseMiddleware<GlobalExceptionHandlerMiddleware>(); // TODO: can be customized
app.UseExceptionHandler();

app.Run();

