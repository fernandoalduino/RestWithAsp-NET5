using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Implementations;

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

        // API Versioning
        services.AddApiVersioning();

        // Dependency Injection
        services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
        services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    { }
}