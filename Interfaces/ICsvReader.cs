using System.Collections.Generic;
using CarRentalSystemApp.Models;

namespace CarRentalSystemApp.Interfaces
{
    public interface ICsvReader<T>
    {
        List<T> ReadItems();
    }
}
