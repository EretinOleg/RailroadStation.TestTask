using Microsoft.Extensions.DependencyInjection;
using RailroadStation.TestTask.Persistence;
using System;

namespace RailroadStation.TestTask.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddPersistence()
                .BuildServiceProvider();

            Console.WriteLine("Hello World!");
        }
    }
}