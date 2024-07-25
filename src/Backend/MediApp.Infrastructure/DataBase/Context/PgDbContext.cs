using MediApp.Infrastructure.DataBase.Entities.Doctor;
using Microsoft.EntityFrameworkCore;

namespace MediApp.Infrastructure.DataBase.Context;

public class PgDbContext : DbContext
{
    public DbSet<DoctorEntity> Doctors { get; set; }

    protected PgDbContext()
    {
    }

    public PgDbContext(DbContextOptions<PgDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgDbContext).Assembly);
    }
}