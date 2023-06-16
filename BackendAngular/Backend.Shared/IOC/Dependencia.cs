using BackEnd.Persistence.Repositories;
using BackEnd.Sahred.Domain.IRepositories;
using BackEnd.Shared.Domain.IRepositories;
using BackEnd.Shared.Domain.IServices;
using BackEnd.Shared.Persistence.Context;
using BackEnd.Shared.Persistence.Repositories;
using BackEnd.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Shared.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICuestionarioService, CuestionarioService>();

            // Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICuestionarioRepository, CuestionarioRepository>();
        }

    }
}
