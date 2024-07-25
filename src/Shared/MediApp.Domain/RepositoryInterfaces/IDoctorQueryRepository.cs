using System.Collections.Immutable;
using MediApp.Domain.Models.Doctor;

namespace MediApp.Domain.RepositoryInterfaces;

public interface IDoctorQueryRepository
{
    public Task<DoctorModel> GetDoctorById(DoctorId doctorId, CancellationToken cancellationToken);
    public Task<ImmutableArray<DoctorModel>> GetDoctors(DoctorFilter? filter, CancellationToken cancellationToken);
    public Task<int> GetDoctorsCount(DoctorFilter? filter, CancellationToken cancellationToken);
}