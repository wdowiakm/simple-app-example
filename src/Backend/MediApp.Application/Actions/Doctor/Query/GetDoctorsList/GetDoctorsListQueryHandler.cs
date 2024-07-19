using System.Collections.Immutable;
using MediApp.Application.Actions.Base;
using MediApp.Domain.Models.Doctor;
using MediApp.Domain.RepositoryInterfaces;

namespace MediApp.Application.Actions.Doctor.Query.GetDoctorsList;

public class GetDoctorsListQueryHandler : IQueryableHandler<GetDoctorsListQuery, ImmutableArray<DoctorModel>>
{
    private readonly IDoctorQueryRepository _doctorQueryRepository;
    
    public GetDoctorsListQueryHandler(IDoctorQueryRepository doctorQueryRepository)
    {
        _doctorQueryRepository = doctorQueryRepository;
    }
    
    public Task<ImmutableArray<DoctorModel>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
    {
        var filter = request is {FirstName: null , LastName: null, LicenseNumber: null}
            ? null
            : new DoctorFilter(
                FirstName: request.FirstName,
                LastName: request.LastName,
                LicenseNumber: request.LicenseNumber
            );
        
        return _doctorQueryRepository.GetDoctors(filter, cancellationToken);
    }
}