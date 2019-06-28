using Microsoft.Extensions.DependencyInjection;
using ProjetoLivraria.Domain.Interfaces;
using ProjetoLivraria.Infra.Data.Repository;

namespace ProjetoLivraria.Infra.CrossCutting.IoC
{                
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<ILivroRepository, LivroRepository>();
        }
    }
}
