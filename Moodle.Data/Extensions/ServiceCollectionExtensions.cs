using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moodle.Core.Interfaces.Data.Repositiries;
using Moodle.Data.Repositories;

namespace Moodle.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseMySql(configuration["Data:ConnectionString"],
                mySqlOpt => mySqlOpt.ServerVersion(configuration["Data:ServerVersion"])));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}