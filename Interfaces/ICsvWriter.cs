using System.Collections.Generic;
using CarRentalSystemApp.Models;

namespace CarRentalSystemApp.Interfaces
{
    public interface ICsvWriter
    {
        void WriteCars(List<Car> cars);
    }
}
