using MediApp.Infrastructure.DataBase.Context;
using MediApp.Infrastructure.FakeData.Fakers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("D:/Repos/simple-app-example/src/Backend/MediApp/appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile("D:/Repos/simple-app-example/src/Backend/MediApp/appsettings.Development.json", optional: false, reloadOnChange: false)
    .Build(); // TODO: change path from absolute to relative

var connectionString = configuration.GetConnectionString("DefaultConnection");
var dbOptions = new DbContextOptionsBuilder<PgDbContext>()
    .UseNpgsql(connectionString)
    .Options;
var context = new PgDbContext(dbOptions);

var fakeDoctors = DoctorFaker.Generate(100);

context.AddRange(fakeDoctors);

var count = await context.SaveChangesAsync();

Console.WriteLine("Added {0} doctors", count);