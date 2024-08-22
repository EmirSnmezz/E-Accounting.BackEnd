using E_Accounting_BackEnd.API.Configurations.Abstraction;
using System.Reflection;

namespace E_Accounting_BackEnd.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallService(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {
            IEnumerable<IServiceRegistration> serviceInstaller = assemblies.SelectMany(a => a.DefinedTypes)
                                                                .Where(IsAssignableToType<IServiceRegistration>)
                                                                .Select(Activator.CreateInstance)
                                                                .Cast<IServiceRegistration>();

            foreach (IServiceRegistration serviceRegistration in serviceInstaller)
            {
                serviceRegistration.Install(services, configuration);
            }

            return services;
        }

        static bool IsAssignableToType<T>(TypeInfo typeInfo) => typeof(T).IsAssignableFrom(typeInfo) &&
                                                            !typeInfo.IsInterface &&
                                                            !typeInfo.IsAbstract;
    }
}
