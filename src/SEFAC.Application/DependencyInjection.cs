using Microsoft.Extensions.DependencyInjection;
using SEFAC.Application.Services;
using SEFAC.Application.Services.Interfaces;
using System.Reflection;

namespace SEFAC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddScoped<IExecucaoAtividadeService, ExecucaoAtividadeService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAtividadeService, AtividadeService>();

            return services;
        }
    }
}
