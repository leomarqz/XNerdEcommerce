
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XNerd.Ecommerce.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//---------------------------------------------------------------------
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

app.MapControllers();

app.Run();
