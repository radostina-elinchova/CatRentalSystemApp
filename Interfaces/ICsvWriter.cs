using System.Collections.Generic;
using CarRentalSystemApp.Models;

namespace CarRentalSystemApp.Interfaces
{
    public interface ICsvWriter<T>
    {
        void WriteItems(List<T> items);
    }
}
