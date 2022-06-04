using AppClinica.Entities;
using AppClinica.Entities.DB;

namespace AppClinica.Repositories;

    public interface IDueñoRepositorio
    {
        void guardarDueños(Dueños dueño);
        List<Dueños> listarDueños();
    }
    public class DueñoRepositorio: IDueñoRepositorio
    {
        private DbEntities _DbEntities;

        public DueñoRepositorio(DbEntities dbEntities)
        {
            _DbEntities = dbEntities;
        }
        public void guardarDueños(Dueños dueño)
        {
            _DbEntities.dueños.Add(dueño);
            _DbEntities.SaveChanges();
        }
        public List<Dueños> listarDueños()
        {
            return _DbEntities.dueños.ToList();
        }
    }

