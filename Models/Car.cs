using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Models
{
    public class Car: Vehicle
    {
        public Car(int id, string make, string model, int year, string type, string status, string? renter = "")
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Type = type;
            this.Status = status;
            this.CurrentRenter = renter;
        }
    }
}
