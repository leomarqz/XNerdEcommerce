
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using XNerd.Ecommerce.Domain.Models;
using XNerd.Ecommerce.Infrastructure;
using XNerd.Ecommerce.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//---------------------------------------------------------------------

builder.Services.AddInfrastructureServices( builder.Configuration );

builder.Services.AddDbContext<EcommerceDbContext>((options) =>
{
    var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(cnnStr, (others) =>
    {   // Mostrara las consultas sql ejecutadas por consola
        others.MigrationsAssembly( typeof(EcommerceDbContext).Assembly.FullName );
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers((options) =>
{   // Esto obliga a que todos los endpoints requieran un token valido
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add( new AuthorizeFilter(policy) );
});

IdentityBuilder identityBuilder = builder.Services.AddIdentityCore<User>();
identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);

// Soporte para los roles y seguridad con tokens
identityBuilder.AddRoles<IdentityRole>().AddDefaultTokenProviders();

// Soporte para claims - son las propiedades que se pueden agregar dentro del token (jwt)
identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, IdentityRole>>();

// Soporte del identity builder en la base de datos (tablas)
identityBuilder.AddEntityFrameworkStores<EcommerceDbContext>();

// soporte para el login
identityBuilder.AddSignInManager<SignInManager<User>>();

// Soporte para la creacion de los datetimes
builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

// Json Web Token
var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( builder.Configuration["JwtSettings:Key"]! ) );

builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme )
    .AddJwtBearer((options) =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

builder.Services.AddCors((options) =>
{
    options.AddPolicy("CorsPolicy", (builder) =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

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

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

using( var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = service.GetRequiredService<EcommerceDbContext>();
        var userManager = service.GetRequiredService<UserManager<User>>();
        var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

        // Ejecuta las migraciones
        await context.Database.MigrateAsync();

        // Cargamos data por defecto
        await EcommerceDbContextData.LoadDataAsync( context, userManager, roleManager, loggerFactory );

    }
    catch (System.Exception e)
    {
        var logger = loggerFactory.CreateLogger( typeof(Program) );
        logger.LogError("Error al ejecutar la migracion inicial...");
    }

}

app.Run();
