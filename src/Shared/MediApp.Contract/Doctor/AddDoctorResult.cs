using MediApp.Domain.Enums;
using MediApp.Domain.Models.Doctor;

namespace MediApp.Contract.Doctor;

public record AddDoctorResult(
    DoctorId Id,
    string FirstName,
    string LastName,
    MedicalLicenseNumber LicenseNumber,
    SpecialityEnum Speciality
)
{
    public string FirstName { get; } = FirstName;
    public string LastName { get; } = LastName;
    public MedicalLicenseNumber LicenseNumber { get; } = LicenseNumber;
    public SpecialityEnum Speciality { get; } = Speciality;
}