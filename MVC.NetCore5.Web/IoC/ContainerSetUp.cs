using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using MVC.NetCore5.Web.Data;
using MVC.NetCore5.Web.Data.Services;
using MVC.NetCore5.Web.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVC.NetCore5.Web.IoC
{
    public static class ContainerSetUp
    {
        public static void SetUp(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            AddServices (services);
            AddUnitOfWork (services, configuration);
            ConfigureCors (services);
        }

        public static void AddServices(IServiceCollection services)
        {
            var serviceType = typeof (BookService);
            var types =
                (
                from t in serviceType.GetTypeInfo().Assembly.GetTypes()
                where
                t.Namespace == serviceType.Namespace && // namespace MVC.NetCore5.Web.Data.Services
                t.GetTypeInfo().IsClass && // Returns all concrete class under the namespace.
                t
                    .GetTypeInfo()
                    .GetCustomAttribute<CompilerGeneratedAttribute>() ==
                null
                select t
                ).ToArray();

            foreach (var type in types)
            {
                var iServiceType = type.GetTypeInfo().GetInterfaces().First();
                services.AddTransient (iServiceType, type);
            }
        }

        private static void AddUnitOfWork(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString =
                configuration["ConnectionStrings:DefaultConnection"];
            services
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
            services
                .AddScoped<IUnitOfWork>(uow =>
                    new EFUnitOfWork(uow
                            .GetRequiredService<ApplicationDbContext>()));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options
                        .AddPolicy("CorsPolicy",
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());
                });
        }
    }
}
