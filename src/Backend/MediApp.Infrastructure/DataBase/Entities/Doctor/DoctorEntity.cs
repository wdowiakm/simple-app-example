using MediApp.Domain.Enums;

namespace MediApp.Infrastructure.DataBase.Entities.Doctor;

public class DoctorEntity
{
    public Guid Id { get; set; }
    public string LicenseNumber { get; set; }
    public SpecialityEnum Speciality { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}