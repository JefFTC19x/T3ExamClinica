using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppClinica.Entities.Mapping;
public class UserMapping : IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.ToTable("Usuario", "dbo");
        builder.HasKey(o=> o.Id);
    }
}