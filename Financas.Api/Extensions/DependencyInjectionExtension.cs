using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Interfaces.Services;
using Financas.Domain.Services;
using Financas.Infra.Data.Repositories;

namespace Financas.Api.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as injeções de dependência
    /// das interfaces e classes do projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Serviços de domínio
            
            services.AddScoped<IContaDomainService, ContaDomainService>();
            services.AddScoped<ICategoriaDomainService, CategoriaDomainService>();
            
            #endregion
            
            #region Repositórios
            
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ICategoriaRepository,CategoriaRepository>();
            
            #endregion
            
            return services;
        }
    }
}
