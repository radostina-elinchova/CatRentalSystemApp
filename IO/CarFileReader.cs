using System.Collections.Generic;
using System.IO;
using CarRentalSystemApp.Models;
using CarRentalSystemApp.Interfaces;

namespace CarRentalSystemApp.IO
{
    public class CarFileReader : ICsvReader<Car>
    {
        private string filePath;

        public CarFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Car> ReadItems()
        {
            var cars = new List<Car>();
            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length >= 7)
                {
                    cars.Add(new Car(
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        parts[4],
                        parts[5],
                        parts[6]
                    ));
                }
            }
            return cars;
        }
    }
}
