using CarRentalSystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Interfaces
{
    public interface IRentable
    {
        void Rent(string renter);
        void Return();
        bool IsAvailable();

    }
}
