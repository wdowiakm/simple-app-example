using Bogus;
using MediApp.Domain.Enums;
using MediApp.Infrastructure.DataBase.Entities.Doctor;

namespace MediApp.Infrastructure.FakeData.Fakers;

public static class DoctorFaker
{
    private static Faker<DoctorEntity>? _faker;
    
    public static Faker<DoctorEntity> GetFaker
    {
        get { return _faker ??= Create(); }
    }
    
    public static IEnumerable<DoctorEntity> Generate(int count) => GetFaker.Generate(count);
    
    private static Faker<DoctorEntity> Create() => new Faker<DoctorEntity>()
        .RuleFor(d => d.Id, f => f.Random.Guid())
        .RuleFor(d => d.LicenseNumber, f => f.Random.String2(10))
        .RuleFor(d => d.Speciality, f => f.PickRandom<SpecialityEnum>())
        .RuleFor(d => d.FirstName, f => f.Name.FirstName())
        .RuleFor(d => d.LastName, f => f.Name.LastName());
}