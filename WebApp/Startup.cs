using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Linq;
using WebApp.Core;
using WebApp.Core.Sqls;
using WebApp.Helpers.Attributes;
using WebApp.Service;
using WebApp.Service.Models;
using WebApp.Service.Models.Enrols;
using WebApp.Sql;
using WebApp.Sql.Entities;
using WebApp.Sql.Entities.Blogs;
using WebApp.Sql.Entities.Enrols;
using static WebApp.Sql.Entities.Identities.IdentityModel;

namespace DotnetCoreApplicationBoilerplate
{
    public class Startup
    {
        readonly string WebAppCorsPolicy = "WebAppCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add<RouteFilterAttribute>();
            //});
            //services.AddScoped<RouteFilterAttribute>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddDbContextDependencies(Configuration);
            services.AddServiceDependency(Configuration);
            services.AddRepositoryDependency();

            var origins = Configuration.GetSection("Domain").Get<Domain>();
            if (origins.Client2.Any()) { origins?.Client1?.AddRange(origins.Client2); }

            services.AddCors(options =>
            {
                options.AddPolicy(WebAppCorsPolicy,
                    builder => builder.WithOrigins(origins?.Client1?.ToArray())
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetCoreApplicationBoilerplate", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetCoreApplicationBoilerplate v1"));
            }

            app.UseCors(WebAppCorsPolicy);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, CommonVariables.AvatarLocation)),
                RequestPath = $"/{CommonVariables.AvatarLocation}"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MasterEntity, MasterModel>()
                 .IncludeAllDerived()
                 .ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<UserBasicInformation, UserBasicInformationModel>().ReverseMap();
            CreateMap<UserHobbyInformation, UserHobbyInformationModel>().ReverseMap();
            CreateMap<UserAddressInformation, UserAddressInformationModel>().ReverseMap();
            CreateMap<UserEducationalInformation, UserEducationalInformationModel>().ReverseMap();
            CreateMap<UserProfessionalInformation, UserProfessionalInformationModel>().ReverseMap();
            CreateMap<UserCertification, UserCertificationModel>().ReverseMap();
            CreateMap<UserSkill, UserSkillModel>().ReverseMap();
            CreateMap<UserInformation, UserInformationModel>()
        
                .ForMember(d => d.Avatar, opts => opts.MapFrom(src => string.IsNullOrEmpty(src.Avatar) ? "" : $"{CommonVariables.AvatarLocation}/{src.Avatar}"))
                .ReverseMap();
            CreateMap<Employees, EmployeesModel>()

               .ForMember(d => d.Avatar, opts => opts.MapFrom(src => string.IsNullOrEmpty(src.Avatar) ? "" : $"{CommonVariables.AvatarLocation}/{src.Avatar}"))
               .ReverseMap();
            CreateMap<Blog, BlogModel>().ReverseMap();
        }
    }
}
