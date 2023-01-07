using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEFAC.Application.Common.Interfaces;
using SEFAC.Domain.Interfaces.Repositories;
using SEFAC.Infrastructure.Persistence;
using SEFAC.Infrastructure.Persistence.Repository;

namespace SEFAC.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IExecucaoAtividadeRepository, ExecucaoAtividadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }

}
