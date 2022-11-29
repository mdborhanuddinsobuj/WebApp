using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebApp.Core;
using WebApp.Core.Acls;
using WebApp.Core.Helpers;
using WebApp.Core.Interface;
using WebApp.Service.Services;
using WebApp.Service.Services.Configurations;
using WebApp.Services;

namespace WebApp.Service
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ISignInHelper, SignInHelper>();
            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
