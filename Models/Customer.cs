using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Rent> Rents { get; private set; }

        public Customer(int id, string name, string phone = null)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Rents = new List<Rent>();
        }

        public void AssignRent(Rent rent)
        {
            this.Rents.Add(rent);
        }
        public override string ToString()
        {
            return $"{this.Id},{this.Name},{this.Phone}";
        }
    }
}
