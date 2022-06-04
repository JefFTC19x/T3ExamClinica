using AppClinica.Entities.DB;


namespace AppClinica.Repositories;

    public interface IUserRepos
    {

    }
    public class UserRepo
    {
        private DbEntities _DbEntities;

        public UserRepo(DbEntities dbEntities)
        {
            _DbEntities = dbEntities;
        }
    }

