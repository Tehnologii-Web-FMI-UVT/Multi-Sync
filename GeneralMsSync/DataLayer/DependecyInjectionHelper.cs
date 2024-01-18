using AspNetCore.Identity.Dapper;

using DataLayer.Repositiory;
using DataLayer.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class DependecyInjectionHelper
    {
        public static void Setup(IServiceCollection serviceCollection)
        {
            SetupDatabase(serviceCollection);
            SetupRepositories(serviceCollection);
        }

        private static void SetupRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUsersRepository, UsersRepository>();
            serviceCollection.AddTransient<IUserRolesRepository, UserRolesRepository>();
            serviceCollection.AddTransient<IPeopleRepository, PeopleRepository>();
        }

        private static void SetupDatabase(IServiceCollection serviceCollection)
        {
            //Add the db connection factory
            serviceCollection.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        }
    }
}
