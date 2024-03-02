using CSharpFunctionalExtensions;
using Microsoft.Extensions.Hosting;
using RailroadStation.TestTask.Application;
using RailroadStation.TestTask.Application.Parks;
using RailroadStation.TestTask.Application.Segments;
using RailroadStation.TestTask.Application.Stations;
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
                        var parks = await host.GetSender().Send(new GetAllParksQuery());
                        Console.WriteLine(string.Empty);
                        foreach (var park in parks.OrderBy(p => p.Id))
                            Console.WriteLine($"{park.Id} - {park}: [{string.Join(", ", park.Routes)}]");
                        PrintInNewLine("Введите номер парка:");
                        
                        var key2 = Console.ReadKey();

                        if (int.TryParse(key2.KeyChar.ToString(), out int parkKey))
                        {
                            var result = await host.GetSender().Send(new ParkFillingQuery(parkKey));
                            PrintInNewLine(result.IsSuccess
                                ? $"Парк {parkKey}. Точки для заливки {string.Join(", ", result.Value.Select(p => $"[{p.X:F0}, {p.Y:F0}]").ToList())}"
                                : result.Error.Message);
                        }
                        else
                            PrintInNewLine("Номер парка должен быть числом.");
                        break;
                    case '2':
                        var segments = await host.GetSender().Send(new GetAllSegmentsQuery());
                        Console.WriteLine(string.Empty);
                        foreach (var segment in segments.OrderBy(p => p.Id))
                            Console.WriteLine($"{segment.Id} - {segment}: [{segment.Start.X:F0}, {segment.Start.Y:F0}] - [{segment.End.X:F0}, {segment.End.Y:F0}]");

                        PrintInNewLine("Введите стартовый отрезок:");
                        var start = Console.ReadLine();
                        PrintInNewLine("Введите конечный отрезок:");
                        var end = Console.ReadLine();

                        if (int.TryParse(start, out int startKey) && int.TryParse(end, out int endKey))
                        {
                            var searchResult = await host.GetSender().Send(new SearchShortestPathQuery(startKey, endKey));
                            PrintInNewLine(searchResult.IsSuccess
                                ? $"Кратчайшее расстояние {searchResult.Value.Sum(x => x.GetLength())}." + 
                                    $" Маршрут: {string.Join(", ", searchResult.Value.Select(x => $"[{x.Start.X:F0}, {x.Start.Y:F0}] - [{x.End.X:F0}, {x.End.Y:F0}]").ToList())}"
                                : searchResult.Error.Message);
                        }
                        else
                            PrintInNewLine("Введены неверные номера отрезков.");
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
            Console.WriteLine("2 - поиск кратчайшего пути");
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