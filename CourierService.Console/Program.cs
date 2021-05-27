using Microsoft.Extensions.DependencyInjection;

namespace CourierService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConsoleServiceProvider provider = new ConsoleServiceProvider())
            {
                var scope = provider.ServiceProvider.CreateScope();
                scope.ServiceProvider.GetService<RunApplication>().Run();
            }
        }
    }
}
