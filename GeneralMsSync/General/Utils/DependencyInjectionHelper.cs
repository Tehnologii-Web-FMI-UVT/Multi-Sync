using RazorPartialToString.Services;

namespace ChurchManagementSystem.Utils
{
    public static class DependencyInjectionHelper
    {
        public static void Setup(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
        }
    }
}
