using System.Collections.Generic;
using System.IO;
using CarRentalSystemApp.Models;
using CarRentalSystemApp.Interfaces;

namespace CarRentalSystemApp.IO
{
    public class CustomerFileReader : ICsvReader<Customer>
    {
        private readonly string filePath;

        public CustomerFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Customer> ReadItems()
        {
            var customers = new List<Customer>();
            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length >= 3)
                {
                    customers.Add(new Customer(
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2]                        
                    ));
                }
            }
            return customers;
        }
    }
}
