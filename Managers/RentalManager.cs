using System;
using CarRentalSystemApp.Models;
using CarRentalSystemApp.Services;

namespace CarRentalSystemApp.Managers
{
    public class RentalManager
    {
        private readonly CarRentalService service;

        public RentalManager(CarRentalService service)
        {
            this.service = service;
        }

        public void DisplayCommands()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("Add Car");
            Console.WriteLine("Rent Car");
            Console.WriteLine("Return Car");
            Console.WriteLine("Edit [ID]");
            Console.WriteLine("List Cars");
            Console.WriteLine("Search [Keyword]");
            Console.WriteLine("Remove [ID]");
            Console.WriteLine("Save & Exit");
        }

        public bool Execute(string command)
        {
            try
            {
                if (command.StartsWith("Add Car"))
                {
                    var input = Console.ReadLine();
                    var data = input.Split(new string[] { ", " }, StringSplitOptions.None);


                    int id;
                    int year;
                    if (!int.TryParse(data[0].Trim(), out id) || !int.TryParse(data[3].Trim(), out year))
                    {
                        Console.WriteLine("Error: ID and Year must be valid integers.");
                        return true;
                    }

                    var car = new Car(
                        id,
                        data[1].Trim(),
                        data[2].Trim(),
                        year,
                        data[4].Trim(),
                        data[5].Trim(),
                        string.Empty
                    );
                    service.AddCar(car);
                    Console.WriteLine("Car added successfully.");
                }
                else if (command.StartsWith("Rent Car"))
                {
                    var data = Console.ReadLine().Split(',');
                    service.RentCar(int.Parse(data[0]), data[1].Trim());
                }
                else if (command.StartsWith("Return Car"))
                {
                    int id = int.Parse(Console.ReadLine());
                    service.ReturnCar(id);
                }
                else if (command.StartsWith("Edit"))
                {
                    int id = int.Parse(command.Split(' ')[1]);
                    var data = Console.ReadLine().Split(',');
                    service.EditCar(id, data[0].Trim(), data[1].Trim(), int.Parse(data[2]), data[3].Trim(), data[4].Trim());
                }
                else if (command.StartsWith("List Cars"))
                {
                    foreach (var car in service.GetCars())
                    {
                        Console.WriteLine(car.ToString());
                    }
                }
                else if (command.StartsWith("Search"))
                {
                    var parts = command.Split(' ', 3); // [Search, Type, Value]
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Invalid search command.");
                        return true;
                    }

                    string type = parts[1].ToLower();
                    string value = parts[2].Trim();

                    var cars = service.GetCars();

                    if (type == "id" && int.TryParse(value, out int id))
                    {
                        var car = CarSearchService.SearchById(cars, id);
                        Console.WriteLine(car != null ? car.ToString() : "No car found with that ID.");
                    }
                    else if (type == "model")
                    {
                        var results = CarSearchService.SearchByModel(cars, value);
                        PrintSearchResults(results);
                    }
                    else if (type == "status")
                    {
                        var results = CarSearchService.SearchByStatus(cars, value);
                        PrintSearchResults(results);
                    }
                    else
                    {
                        Console.WriteLine("Invalid search type.");
                    }
                }
                else if (command.StartsWith("Remove"))
                {
                    int id = int.Parse(command.Split(' ')[1]);
                    service.RemoveCar(id);
                }
                else if (command == "Save & Exit")
                {
                    service.SaveChanges();
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return true;
        }
        void PrintSearchResults(List<Car> results)
        {
            if (results.Any())
            {
                foreach (var car in results)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("No cars found.");
            }
        }
    }
}
