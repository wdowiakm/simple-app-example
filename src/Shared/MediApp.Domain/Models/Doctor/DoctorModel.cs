using MediApp.Domain.Enums;
using MediApp.Domain.Models.Person;

namespace MediApp.Domain.Models.Doctor;

public record DoctorModel(
    DoctorId Id,
    MedicalLicenseNumber LicenseNumber,
    SpecialityEnum Speciality,
    string FirstName,
    string LastName
) : PersonModel(FirstName, LastName);