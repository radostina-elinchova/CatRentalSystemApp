using System.Collections.Generic;
using System.IO;
using CarRentalSystemApp.Models;
using CarRentalSystemApp.Interfaces;

namespace CarRentalSystemApp.IO
{
    public class CustomerFileWriter : ICsvWriter<Customer>
    {
        private readonly string filePath;

        public CustomerFileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteItems(List<Customer> customers)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Id,Name,Phone");
                    foreach (var customer in customers)
                    {
                        writer.WriteLine(customer.ToString());
                    }
                }

                Console.WriteLine("Cars saved successfully to CSV.");
                Console.WriteLine($"[DEBUG] Saved {customers.Count} cars to '{Path.GetFullPath(filePath)}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save cars: {ex.Message}");
            }
        }
    }
}
