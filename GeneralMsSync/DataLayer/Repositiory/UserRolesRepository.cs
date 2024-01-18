using AspNetCore.Identity.Dapper;

using DataLayer.Models;

namespace DataLayer.Repositories
{
    public interface IUserRolesRepository
    {
        public Task<IList<UserRole>> GetAllRolesForUser(ulong userId);
    }

    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly IDbConnectionFactory mDbConnectionFactory;
        
        public UserRolesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            mDbConnectionFactory = dbConnectionFactory;
        }

        public Task<IList<UserRole>> GetAllRolesForUser(ulong userId)
        {
            throw new NotImplementedException();
        }
    }
}
