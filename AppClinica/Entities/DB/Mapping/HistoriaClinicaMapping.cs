using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClinica.Entities.DB.Mapping;

public class HistoriaClinicaMapping: IEntityTypeConfiguration<HistoriaClinica>
{
    public void Configure(EntityTypeBuilder<HistoriaClinica> builder)
    {
        builder.ToTable("HistoriaClinica", "dbo");
        builder.HasKey(o=> o.codRegistro);

        builder.HasOne(o => o.Mascota)
            .WithMany()
            .HasForeignKey(o=>o.IdMascota);

    }
}

