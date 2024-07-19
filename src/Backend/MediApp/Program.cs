using System.Text.Json.Serialization;
using MediApp.Api;
using MediApp.Application.Actions.Doctor.Query.GetDoctorsList;
using MediApp.Domain.RepositoryInterfaces;
using MediApp.Infrastructure.DataBase.Context;
using MediApp.Infrastructure.DataBase.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IInMemoryContext, InMemoryContext>();
builder.Services.AddScoped<IDoctorQueryRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorCommandRepository, DoctorRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetDoctorsListQuery).Assembly);
});

builder.Services.AddControllers()
    .AddApplicationPart(typeof(DoctorsController).Assembly)
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
