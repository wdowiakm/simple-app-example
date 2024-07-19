using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediApp.Application.Actions.Base;
using MediApp.Contract.Doctor;
using MediApp.Domain.Models.Doctor;
using MediApp.Domain.RepositoryInterfaces;

namespace MediApp.Application.Actions.Doctor.Command.AddDoctor;

public class AddDoctorCommandHandler : ICommandHandler<AddDoctorCommand, AddDoctorResult>
{
    private readonly IDoctorQueryRepository _doctorQueryRepository;
    private readonly IDoctorCommandRepository _doctorCommandRepository;
    
    public AddDoctorCommandHandler(
        IDoctorQueryRepository doctorQueryRepository, 
        IDoctorCommandRepository doctorCommandRepository)
    {
        _doctorQueryRepository = doctorQueryRepository;
        _doctorCommandRepository = doctorCommandRepository;
    }
    
    public async Task<AddDoctorResult> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctorsFilter = new DoctorFilter(LicenseNumber: request.LicenseNumber);
        var doctor = (await _doctorQueryRepository.GetDoctors(doctorsFilter, cancellationToken)).FirstOrDefault();
        
        if (doctor is not null) throw new Exception("Doctor already exists");
        
        var newDoctor = new DoctorModel(
            new DoctorId(),
            request.LicenseNumber,
            request.Speciality,
            request.FirstName, 
            request.LastName
        );
        
        await _doctorCommandRepository.AddDoctor(newDoctor, cancellationToken);
        
        return new AddDoctorResult(
            newDoctor.Id,
            newDoctor.FirstName,
            newDoctor.LastName,
            newDoctor.LicenseNumber,
            newDoctor.Speciality
        );
    }
}