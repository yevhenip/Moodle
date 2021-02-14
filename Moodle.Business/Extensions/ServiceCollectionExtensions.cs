using Microsoft.Extensions.DependencyInjection;
using Moodle.Business.Services;
using Moodle.Core.Interfaces.Services;

namespace Moodle.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IMainFileService, MainFileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherCourseService, TeacherCourseService>();
        }
    }
}