using BackEnd.Shared.Persistence.Context;
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

            //string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContextPool<AplicationDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IVentaRepository, VentaRepository>();

            //services.AddAutoMapper(typeof(AutoMapperProfile));


            //services.AddScoped<IRolService, RolService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<ICategoriaService, CategoriaService>();
            //services.AddScoped<IProductoService, ProductoService>();
            //services.AddScoped<IVentaService, VentaService>();
            //services.AddScoped<IDashBoardService, DashBoardService>();
            //services.AddScoped<IMenuService, MenuService>();

        }

    }
}
