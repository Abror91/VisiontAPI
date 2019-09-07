using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.BLL.Infrastructure.Services;
using Vision.BLL.Services;
using Vision.DAL.Infrastructure;

namespace Vision.BLL.Infrastructure
{
    public class ModuleInitializer
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<EmployeeService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            services.AddScoped(typeof(IEntityServiceWithMapping<,>), typeof(EntityServiceWithMapping<,>));
        }
    }
}
