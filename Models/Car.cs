using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string? CurrentRenter { get; set; }

        public Car(int id, string make, string model, int year, string type, string status, string renter=null)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            Status = status;
            CurrentRenter = renter;
        }
        public override string ToString()
        {
            return $"{Id},{Make},{Model},{Year},{Type},{Status},{CurrentRenter}";
        }
    }
}
