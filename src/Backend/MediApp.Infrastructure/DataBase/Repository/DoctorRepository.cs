using System.Collections.Immutable;
using MediApp.Domain.Models.Doctor;
using MediApp.Domain.RepositoryInterfaces;
using MediApp.Infrastructure.DataBase.Entities.Doctor;

namespace MediApp.Infrastructure.DataBase.Repository;

public class DoctorQueryRepository : IDoctorQueryRepository
{
    private Dictionary<Guid, DoctorEntity> _doctors = new();
    
    public Task<DoctorModel> GetDoctorById(DoctorId doctorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableArray<DoctorModel>> GetDoctors(DoctorFilter? filter, CancellationToken cancellationToken)
    {
        if (filter is null)
        {
            var doctors = _doctors.Values.Select(d => new DoctorModel(
                new DoctorId(d.Id),
                new MedicalLicenseNumber(d.LicenseNumber),
                d.Speciality,
                d.FirstName,
                d.LastName
            )).ToImmutableArray();
            
            return Task.FromResult(doctors);
        }

        return Task.FromResult(ImmutableArray.Create<DoctorModel>());
    }

    public Task<int> GetDoctorsCount(DoctorFilter? filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
}

public class DoctorCommandRepository : IDoctorCommandRepository
{
    private Dictionary<Guid, DoctorEntity> _doctors = new();
    

    public Task<DoctorModel> AddDoctor(DoctorModel doctorModel, CancellationToken cancellationToken)
    {
        var doctorEntity = new DoctorEntity
        {
            Id = doctorModel.Id,
            LicenseNumber = doctorModel.LicenseNumber,
            Speciality = doctorModel.Speciality,
            FirstName = doctorModel.FirstName,
            LastName = doctorModel.LastName
        };
        
        _doctors.Add(doctorModel.Id, doctorEntity);
        
        return Task.FromResult(doctorModel);
    }

    public Task<DoctorModel> EditDoctor(DoctorModel doctorModel, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDoctor(DoctorId doctorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}