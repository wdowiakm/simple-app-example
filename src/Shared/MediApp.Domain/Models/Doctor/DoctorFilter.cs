namespace MediApp.Domain.Models.Doctor;

public record DoctorFilter(
    string? FirstName = null,
    string? LastName = null,
    MedicalLicenseNumber? LicenseNumber = null
);