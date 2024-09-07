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

    /*
     Assembly: Bir .NET uygulamasında, "assembly" genellikle bir derleme dosyasıdır (örneğin, bir DLL veya EXE dosyası). Bu dosya, uygulamanın kodlarını ve metadata bilgilerini içerir.

Kod Açıklaması:

assemblies.SelectMany(a => a.DefinedTypes):

assemblies, bir dizi assembly'yi temsil eder.
SelectMany, her bir assembly'nin içindeki tüm türleri (class, interface, vb.) tek bir liste halinde toplar. DefinedTypes, bir assembly'deki tüm türleri getirir.
.Where(IsAssignableToType<IServiceRegistration>):

Burada, önceki adımda elde edilen tür listesinden sadece IServiceRegistration arayüzünü uygulayanları seçiyoruz.
IsAssignableToType<IServiceRegistration> fonksiyonu, türün bu arayüzü implement edip etmediğini kontrol eder.
.Select(Activator.CreateInstance):

Bu adım, seçilen türlerden her birinin bir örneğini (instance) yaratır.
Activator.CreateInstance, türün yeni bir nesnesini oluşturur.
.Cast<IServiceRegistration>():

Oluşturulan nesneleri IServiceRegistration tipine dönüştürür.
Bu, tüm nesnelerin IServiceRegistration arayüzü ile uyumlu olduğunu garanti eder.
Sonuç olarak, bu kod parçası, IServiceRegistration arayüzünü uygulayan tüm türlerin örneklerini dinamik olarak oluşturur ve bu örnekleri bir liste halinde sunar.
     */
}
