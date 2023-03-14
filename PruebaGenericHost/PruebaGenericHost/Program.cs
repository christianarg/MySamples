using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PruebaGenericHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using var host = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<SampleHosted>();
            }).Build();
            host.Run();
        }
    }

    public class SampleHosted : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StartAsync");
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StopAsync");
            await Task.CompletedTask;
        }
    }
}