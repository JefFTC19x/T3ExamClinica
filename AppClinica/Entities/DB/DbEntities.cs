using AppClinica.Entities.DB.Mapping;
using AppClinica.Entities.Mapping;

namespace AppClinica.Entities.DB;

using Microsoft.EntityFrameworkCore;
public class DbEntities : DbContext
{
    public DbSet<Dueños> dueños { get; set; }
    public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
    public DbSet<Mascota> mascotas { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    public DbEntities(){}

    public DbEntities(DbContextOptions<DbEntities> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new DueñoMapping());
        modelBuilder.ApplyConfiguration(new HistoriaClinicaMapping());
        modelBuilder.ApplyConfiguration(new MascotaMapping());
        

    }

}

