using System.Collections.Immutable;
using MediApp.Domain.Models.Doctor;
using MediApp.Domain.RepositoryInterfaces;
using MediApp.Infrastructure.DataBase.Context;
using MediApp.Infrastructure.DataBase.Entities.Doctor;
using Microsoft.EntityFrameworkCore;

namespace MediApp.Infrastructure.DataBase.Repository;

public class DoctorRepository : IDoctorQueryRepository, IDoctorCommandRepository
{
    private readonly PgDbContext _context;

    public DoctorRepository(PgDbContext context)
    {
        _context = context;
    }

    public Task<DoctorModel> GetDoctorById(DoctorId doctorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ImmutableArray<DoctorModel>> GetDoctors(DoctorFilter? filter, CancellationToken cancellationToken)
    {
        if (filter is null)
        {
            var doctors = (await _context.Doctors
                    .Select(d => new DoctorModel(
                        new DoctorId(d.Id),
                        new MedicalLicenseNumber(d.LicenseNumber),
                        d.Speciality,
                        d.FirstName,
                        d.LastName))
                    .AsNoTracking()
                    .ToArrayAsync(cancellationToken)) // TODO: remove double conversion for better performance
                .ToImmutableArray();
            
            return doctors;
        }

        return await Task.FromResult(ImmutableArray.Create<DoctorModel>());
    }

    public Task<int> GetDoctorsCount(DoctorFilter? filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<DoctorModel> AddDoctor(DoctorModel doctorModel, CancellationToken cancellationToken)
    {
        var doctorEntity = new DoctorEntity
        {
            Id = doctorModel.Id,
            LicenseNumber = doctorModel.LicenseNumber,
            Speciality = doctorModel.Speciality,
            FirstName = doctorModel.FirstName,
            LastName = doctorModel.LastName
        };
        
        await _context.Doctors.AddAsync(doctorEntity, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);

        return (DoctorModel)doctorEntity;
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