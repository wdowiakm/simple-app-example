using System.Collections.Immutable;
using MediApp.Domain.Models.Doctor;
using MediatR;

namespace MediApp.Application.Actions.Doctor.Query.GetDoctorsList;

public class GetDoctorsListQuery(
    string? firstName = null,
    string? lastName = null,
    MedicalLicenseNumber? licenseNumber = null
) : IRequest<ImmutableArray<DoctorModel>>
{
    public string? FirstName { get; } = firstName;
    public string? LastName { get; } = lastName;
    public MedicalLicenseNumber? LicenseNumber { get; } = licenseNumber;
}