using System;
using System.Collections.Generic;
using MediApp.Infrastructure.DataBase.Entities.Doctor;

namespace MediApp.Infrastructure.DataBase.Context;

public class InMemoryContext : IInMemoryContext
{
    public Dictionary<Guid, DoctorEntity> Doctors { get; init; } = new();
}

public interface IInMemoryContext
{
    public Dictionary<Guid, DoctorEntity> Doctors { get; init; }
}