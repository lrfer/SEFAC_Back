

using SEFAC.Domain.Const;

namespace SEFac.Api.Config
{
    public static class CorsConfig
    {
        public static  IServiceCollection AddCorsConfiguration (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(Policy.AllowAll, p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                options.AddPolicy(Policy.SEFAC, p =>
                {
                    p.WithOrigins(configuration["AllowApplicationUrl"].Split(","))
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            return services;
        }
    }
}
