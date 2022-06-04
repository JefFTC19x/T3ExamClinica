using AppClinica.Entities;
using AppClinica.Entities.DB;
using Microsoft.EntityFrameworkCore;


namespace AppClinica.Repositories;

    public interface IHistoriaClinicaRepositorio
    {
        List<HistoriaClinica> obtenerHistorias();
        void guardarHistoriaClinica(HistoriaClinica historiaClinica);
    }
    public class HistoriaClinicaRepositorio : IHistoriaClinicaRepositorio
    {
        private DbEntities _DbEntities;

        public HistoriaClinicaRepositorio(DbEntities dbEntities)
        {
            _DbEntities = dbEntities;
        }

        public List<HistoriaClinica> obtenerHistorias()
        {
            return _DbEntities.HistoriasClinicas
                .Include(o => o.Mascota)
                .Include(o => o.Mascota.Dueño)
                .ToList();
        }

        public void guardarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            _DbEntities.HistoriasClinicas.Add(historiaClinica);
            _DbEntities.SaveChanges();
        }
    }

