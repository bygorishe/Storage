using Core.Domain.Entities;
using Storage.MainConsole.Data;
using Storage.MainConsole.Repositories;
using Storage.MainConsole.Services;

namespace Storage
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var consoleService = new ConsoleService(new LocalRepository<Pallet>(InMemoryDatas.Pallets));

            Console.WriteLine("Task1");
            await consoleService.Task1();

            Console.WriteLine("\nTask2");
            await consoleService.Task2();
        }
    }
}