using System;

namespace MediApp.Domain.Models.Doctor;

public record struct DoctorId(Guid Value)
{
    public DoctorId() : this(Guid.NewGuid()) { }
    
    public static implicit operator Guid(DoctorId self) => self.Value;
    public static implicit operator DoctorId(Guid value) => new(value);
}