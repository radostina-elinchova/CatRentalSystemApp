using CarRentalSystemApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Models
{
    public class Car: Vehicle, ISearchable, IRentable
    {
        public Car(int id, string make, string model, int year, string type, string status, String? renter = null)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Type = type;
            this.Status = status;
            this.CurrentRenter = renter;
        }

       
        public bool MatchesId(int id)
        {
            return this.Id == id;
        }

        public bool MatchesModel(string model)
        {
            return this.Model.Equals(model, StringComparison.OrdinalIgnoreCase);
        }

        public bool MatchesStatus(string status)
        {
            return this.Status.Equals(status, StringComparison.OrdinalIgnoreCase);
        }

        public void Rent(string renterName)
        {
            if (IsAvailable())
            {
                this.Status = "Rented";
                this.CurrentRenter = renterName;
                

            }
            else
            {
                throw new InvalidOperationException("Car is not available for rent.");
            }
        }

        public void Return()
        {
            if (!IsAvailable())
            {
                this.Status = "Available";
                this.CurrentRenter = "";
            }
            else
            {
                throw new InvalidOperationException("Car is already available.");
            }
        }

        public bool IsAvailable()
        {
            return Status.Equals("Available", StringComparison.OrdinalIgnoreCase);
        }
    }
}
