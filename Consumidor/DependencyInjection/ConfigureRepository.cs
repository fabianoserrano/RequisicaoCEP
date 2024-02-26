using ServiceRequisicaoCEP.Interfaces;
using ServiceRequisicaoCEP.Repository;

namespace ServiceRequisicaoCEP.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRequisicaoCepRepository, RequisicaoCepRepository>();
        }
    }
}
