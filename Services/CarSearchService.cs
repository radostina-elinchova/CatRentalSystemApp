using CarRentalSystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Services
{
    public static class CarSearchService
    {
        public static Car? SearchById(List<Car> cars, int id)
        {
            return cars.FirstOrDefault(c => c.Id == id);
        }

        public static List<Car> SearchByModel(List<Car> cars, string model)
        {
            return cars.Where(c => c.Model.Equals(model, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Car> SearchByStatus(List<Car> cars, string status)
        {
            return cars.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
