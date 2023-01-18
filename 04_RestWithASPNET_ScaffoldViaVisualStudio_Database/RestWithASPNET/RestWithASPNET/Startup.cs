using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Services;
using RestWithASPNET.Services.Implementations;

class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    { 
        services.AddControllers();

        var connection = Configuration["MySQLConnection:MySQLConnectionString"];

        services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

        // Dependency Injection
        services.AddScoped<IPersonService, PersonServiceImplementation>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    { }
}