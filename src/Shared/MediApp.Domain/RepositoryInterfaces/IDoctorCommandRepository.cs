using System.Threading;
using System.Threading.Tasks;
using MediApp.Domain.Models.Doctor;

namespace MediApp.Domain.RepositoryInterfaces;

public interface IDoctorCommandRepository
{
    public Task<DoctorModel> AddDoctor(DoctorModel doctorModel, CancellationToken cancellationToken);
    public Task<DoctorModel> EditDoctor(DoctorModel doctorModel, CancellationToken cancellationToken);
    public Task DeleteDoctor(DoctorId doctorId, CancellationToken cancellationToken);
}