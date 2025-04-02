using TaskManagement.Manager;
using TaskManagement.Repository;

namespace TaskManagement
{
    public static class RegisterServices
    {
        public static void RegisterService(IServiceCollection services)
        {
            Configure(services, DataRegister.GetTypes());
            Configure(services, ServicesRegister.GetTypes());
        }
        private static void Configure(IServiceCollection services, Dictionary<Type, Type> dictionary)
        {
            foreach (var type in dictionary)
            {
                services.AddScoped(type.Key, type.Value);
            }
            services.AddDataProtection();

            services.AddSignalR();
            // Register the ClientSignalr implementation
            //services.AddSingleton<IClientSignalr, signalrHubs>();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddMvc();
            services.AddHttpContextAccessor();
        }
    }
}
