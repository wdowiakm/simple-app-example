using MediApp.Infrastructure.DataBase.Entities.Doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediApp.Infrastructure.DataBase.EntitiesConfig;

public class DoctorEntityConfig : IEntityTypeConfiguration<DoctorEntity>
{
    public void Configure(EntityTypeBuilder<DoctorEntity> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.LicenseNumber)
            .IsRequired()
            .HasColumnType("varchar(25)");
        
        builder.Property(d => d.Speciality)
            .IsRequired();
        
        builder.Property(d => d.FirstName)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.Property(d => d.LastName)
            .IsRequired()
            .HasColumnType("varchar(100)");
    }
}