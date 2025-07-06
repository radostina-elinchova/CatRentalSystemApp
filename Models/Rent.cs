using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Models
{
    public class Rent
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedReturn { get; set; }

        public Rent(int CarId, int CustomerId, DateTime expectedReturn)
        {
            this.CarId = CarId;
            this.CustomerId = CustomerId;
            this.StartDate = DateTime.Now;
            this.ExpectedReturn = expectedReturn;
        }
    }
}
