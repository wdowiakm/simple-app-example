using MediApp.Domain.Enums;
using MediApp.Domain.Models.Doctor;

namespace MediApp.Infrastructure.DataBase.Entities.Doctor;

public class DoctorEntity
{
    public Guid Id { get; set; }
    public string LicenseNumber { get; set; }
    public SpecialityEnum Speciality { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public static explicit operator DoctorModel(DoctorEntity entity) => new(
        entity.Id,
        entity.LicenseNumber,
        entity.Speciality,
        entity.FirstName,
        entity.LastName
    );
}