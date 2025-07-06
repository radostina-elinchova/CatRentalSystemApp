using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Models
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public String? CurrentRenter { get; set; }        

        public override string ToString()
        {
            return $"{this.Id},{this.Make},{this.Model},{this.Year},{this.Type},{this.Status},{this.CurrentRenter}";
        }
    }
}
