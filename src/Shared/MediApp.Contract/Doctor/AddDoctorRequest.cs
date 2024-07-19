using MediApp.Domain.Enums;

namespace MediApp.Contract.Doctor;

public record AddDoctorRequest(
    string FirstName,
    string LastName,
    string LicenseNumber,
    SpecialityEnum Speciality
)
{
    public string FirstName { get; } = FirstName;
    public string LastName { get; } = LastName;
    public string LicenseNumber { get; } = LicenseNumber;
    public SpecialityEnum Speciality { get; } = Speciality;
}