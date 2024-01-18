using AspNetCore.Identity.Dapper;

using CMSShared;

using DataLayer.Models;

namespace DataLayer.Repositories
{
    public interface IUsersRepository
    {
        public Task<(string message, EResultStatus status, User user)> Authenticate(string userName, string password);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnectionFactory mDbConnectionFactory;

        public UsersRepository(IDbConnectionFactory dbConnectionFactory)
        {
            mDbConnectionFactory = dbConnectionFactory;
        }

        public Task<(string message, EResultStatus status, User user)> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
