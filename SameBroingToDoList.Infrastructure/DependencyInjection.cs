using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SameBroingToDoList.Application.Services;
using SameBroingToDoList.Domain.Repositories;
using SameBroingToDoList.Infrastructure.Persistence.Options;
using SameBroingToDoList.Infrastructure.Persistence.Repositories;
using SameBroingToDoList.Infrastructure.Services;
using SameBroingToDoList.Shared;

namespace SameBroingToDoList.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuth(configuration);
            services.AddScoped<IToDoListRepository, ToDoListRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            var options = configuration.GetOptions<SqlOptions>("SqlServer");
            services.AddDbContext<SameBroingToDoListDbContext>(context =>
                context.UseSqlServer(options.ConnectionString));
            return services;

        }

        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IUserContextService<Guid>, UserContextService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
