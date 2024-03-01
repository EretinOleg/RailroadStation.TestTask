using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RailroadStation.TestTask.Application;
using RailroadStation.TestTask.Application.Parks;
using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Infrastructure;
using RailroadStation.TestTask.Persistence;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadStation.TestTask.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (var host = CreateHostBuilder(args).Build())
            {
                await Start(host, args);
            }
        }

        private static async Task Start(IHost host, string[] args)
        {
            PrintMenu();

            var working = true;
            while (working)
            {
                var key = Console.ReadKey();
                switch(key.KeyChar)
                {
                    case '1':
                        PrintInNewLine("Введите номер парка:");
                        var key2 = Console.ReadKey();

                        if (int.TryParse(key2.KeyChar.ToString(), out int parkKey))
                        {
                            var result = await host.Services.GetRequiredService<ISender>().Send(new ParkFillingQuery(parkKey));
                            PrintInNewLine(result.IsSuccess
                                ? $"Парк {parkKey}. Точки для заливки {string.Join(", ", result.Value.Select(p => $"[{p.X:F0}, {p.Y:F0}]").ToList())}"
                                : result.Error.Message);
                        }
                        else
                            PrintInNewLine("Номер парка должен быть числом.");
                        break;
                    case '0':
                        working = false;
                        break;
                    default:
                        PrintInNewLine("Неизвестная команда");
                        break;
                };

                Console.WriteLine("");
                PrintMenu();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - заливка парка");
            Console.WriteLine("0 - выход");
        }

        private static void PrintInNewLine(string message)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(message);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => services
                    .AddPersistence()
                    .AddInfrastructure()
                    .AddApplication());
        }
    }
}