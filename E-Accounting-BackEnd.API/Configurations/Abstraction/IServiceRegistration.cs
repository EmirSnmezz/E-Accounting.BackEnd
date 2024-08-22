namespace E_Accounting_BackEnd.API.Configurations.Abstraction
{
    public interface IServiceRegistration
    {
        void Install(IServiceCollection services, IConfiguration configuration);
    }
}
