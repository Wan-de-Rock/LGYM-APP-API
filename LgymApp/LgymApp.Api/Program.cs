using System.Text;
using LgymApp.Api.Endpoints;
using LgymApp.Api.Endpoints.Auth;
using LgymApp.Api.Middlewares;
using LgymApp.Application.Interfaces;
using LgymApp.Application.Options;
using LgymApp.Application.Services;
using LgymApp.DataAccess;
using LgymApp.DataAccess.Interfaces;
using LgymApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(nameof(AuthOptions)));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

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

app.MapUsersEndpoints(); // TODO: make dynamic

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
