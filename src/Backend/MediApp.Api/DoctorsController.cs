using MediApp.Application.Actions.Doctor.Command.AddDoctor;
using MediApp.Application.Actions.Doctor.Query.GetDoctorsList;
using MediApp.Contract;
using MediApp.Contract.Doctor;
using MediApp.Domain.Models.Doctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediApp.Api;

[ApiController]
[Route("api/doctors")]
public class DoctorsController : Controller
{
    private readonly IMediator _mediator;
    
    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetDoctorById(
        [FromQuery] Guid id, 
        CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetDoctorsList(
        [FromQuery] DoctorFilter filter, 
        CancellationToken cancellationToken)
    {
        var query = new GetDoctorsListQuery(
            filter.FirstName,
            filter.LastName,
            filter.LicenseNumber
        );
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddDoctor(
        [FromBody] AddDoctorRequest request, 
        CancellationToken cancellationToken)
    {
        var command = new AddDoctorCommand(
            request.FirstName,
            request.LastName,
            request.LicenseNumber,
            request.Speciality
        );
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateDoctor(
        [FromQuery] Guid id, 
        [FromBody] UpdateDoctorRequest request, 
        CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDoctor(
        [FromQuery] Guid id, 
        CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    
}
