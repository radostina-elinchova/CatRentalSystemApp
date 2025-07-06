using CarRentalSystemApp.IO;
using CarRentalSystemApp.Services;
using CarRentalSystemApp.Managers;

namespace CatRentalSystemApp
{
    public class CatRentalSystem
    {
        static void Main(string[] args)
        {
            var carReader = new CarFileReader("cars.csv");
            var carWriter = new CarFileWriter("cars.csv");
            var customerReader = new CustomerFileReader("customers.csv");
            var customerWriter = new CustomerFileWriter("customers.csv");
            var service = new CarRentalService(carReader, carWriter, customerReader, customerWriter);
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
