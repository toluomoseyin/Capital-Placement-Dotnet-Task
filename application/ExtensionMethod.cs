using application.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class ExtensionMethod
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

        }
    }
}
