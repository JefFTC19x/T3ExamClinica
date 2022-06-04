using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClinica.Entities.Mapping;

public class DueñoMapping:IEntityTypeConfiguration<Dueños>
{
    public void Configure(EntityTypeBuilder<Dueños> builder)
    {
        builder.ToTable("Dueños", "dbo");
        builder.HasKey(o=> o.Id);
       
    }
}