using System.Runtime.CompilerServices;
using ClickerWebProject.Domain;
using ClickerWebProject.Infrastructure.DataAccess;
using ClickerWebProject.Initilizers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpClicker.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.MapHealthChecks("health-check");

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddHealthChecks();
        //services.AddIdentity<ApplicationUser, ApplicationRole>()
        //    .AddEntityFrameworkStores<AppDbContext>()
        //    .AddDefaultTokenProviders();

        DbContextInitializer.InitializeDbContext(services);
    }
}
