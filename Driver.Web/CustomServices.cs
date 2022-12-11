using dwa = Driver.Web.Application;
using Driver.Web.Application.Contracts;

namespace Driver.Web{
    public static class CustomServices{
        public static IServiceCollection AddCustomServices(this IServiceCollection services){

            services.AddScoped<IArrays, dwa.Arrays>();

            return services;
        }
    }
}