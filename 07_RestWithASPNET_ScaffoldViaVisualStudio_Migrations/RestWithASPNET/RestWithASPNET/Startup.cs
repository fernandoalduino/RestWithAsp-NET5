using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Implementations;
using Serilog;
using MySqlConnector;

class Startup
{
    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;

        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        var connection = Configuration["MySQLConnection:MySQLConnectionString"];

        services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

        if (Environment.IsDevelopment())
        {
            MigrateDatabase(connection);
        }

        // API Versioning
        services.AddApiVersioning();

        // Dependency Injection
        services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
        services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

        services.AddScoped<IBookBusiness, BookBusinessImplementation>();
        services.AddScoped<IBookRepository, BookRepositoryImplementation>();
    }

    private void MigrateDatabase(string connection)
    {
        try { 
            var evolveConnection = new MySqlConnection(connection);
            var evolve = new EvolveDb.Evolve(evolveConnection, msg => Log.Information(msg))
            {
                Locations = new List<string>
                {
                    "db/migrations",
                    "db/dataset"
                },
                IsEraseDisabled = true,
            };
            evolve.Migrate();
        }
        catch(Exception ex) {
            Log.Error("Database migration failed", ex);
            throw;
        }
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    { }
}