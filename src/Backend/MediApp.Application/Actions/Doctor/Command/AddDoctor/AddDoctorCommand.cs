using MediApp.Contract.Doctor;
using MediApp.Domain.Enums;
using MediApp.Domain.Models.Doctor;
using MediatR;

namespace MediApp.Application.Actions.Doctor.Command.AddDoctor;

public class AddDoctorCommand(
    string firstName,
    string lastName,
    MedicalLicenseNumber licenseNumber,
    SpecialityEnum speciality
) : IRequest<AddDoctorResult>
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public MedicalLicenseNumber LicenseNumber { get; } = licenseNumber;
    public SpecialityEnum Speciality { get; } = speciality;
}