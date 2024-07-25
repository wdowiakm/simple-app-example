using MediApp.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("D:/Repos/simple-app-example/src/Backend/MediApp/appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile("D:/Repos/simple-app-example/src/Backend/MediApp/appsettings.Development.json", optional: false, reloadOnChange: false)
    .Build(); // TODO: change path from absolute to relative

var connectionString = configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<PgDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

services.BuildServiceProvider();

Console.WriteLine("This is a migration project!");