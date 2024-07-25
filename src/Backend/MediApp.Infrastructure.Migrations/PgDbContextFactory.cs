using MediApp.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MediApp.Infrastructure.Migrations;

public class PgDbContextFactory : IDesignTimeDbContextFactory<PgDbContext>
{
    public PgDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PgDbContext>();
        
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("D:/Repos/simple-app-example/src/Backend/MediApp/appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile("D:/Repos/simple-app-example/src/Backend/MediApp/appsettings.Development.json", optional: false, reloadOnChange: false)
            .Build(); // TODO: change path from absolute to relative

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        optionsBuilder.UseNpgsql(
            connectionString, 
            x => x.MigrationsAssembly(typeof(PgDbContextFactory).Assembly.FullName)
        );
        
        return new PgDbContext(optionsBuilder.Options);
    }
}