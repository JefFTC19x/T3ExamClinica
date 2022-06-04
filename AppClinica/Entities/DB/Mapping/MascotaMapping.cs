using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClinica.Entities.Mapping;

public class MascotaMapping: IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascota", "dbo");
            builder.HasKey(o=> o.ID);

            builder.HasOne(o => o.Dueño)
                .WithMany()
                .HasForeignKey(o=> o.IdDueño);
        }
        
}