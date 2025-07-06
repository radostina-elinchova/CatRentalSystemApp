using CarRentalSystemApp.IO;
using CarRentalSystemApp.Services;
using CarRentalSystemApp.Managers;

namespace CatRentalSystemApp
{
    internal class CatRentalSystem
    {
        static void Main(string[] args)
        {
            var reader = new CarFileReader("cars.csv");
            var writer = new CarFileWriter("cars.csv");
            var service = new CarRentalService(reader, writer);
            var manager = new RentalManager(service);

            Console.WriteLine("Welcome to the Car Rental System");
            manager.DisplayCommands();

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                isRunning = manager.Execute(command);
            }
        }
    }
}
