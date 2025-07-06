using System.Collections.Generic;
using System.IO;
using CarRentalSystemApp.Models;
using CarRentalSystemApp.Interfaces;

namespace CarRentalSystemApp.IO
{
    public class CarFileWriter : ICsvWriter<Car>
    {
        private readonly string filePath;

        public CarFileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteItems(List<Car> cars)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Id,Make,Model,Year,Type,Status,CurrentRenter");
                    foreach (var car in cars)
                    {
                        writer.WriteLine(car.ToString());
                    }
                }

                Console.WriteLine("Cars saved successfully to CSV.");
                Console.WriteLine($"[DEBUG] Saved {cars.Count} cars to '{Path.GetFullPath(filePath)}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save cars: {ex.Message}");
            }
        }
    }
}
