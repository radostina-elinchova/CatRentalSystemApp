using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystemApp.Interfaces;
using CarRentalSystemApp.Models;


namespace CarRentalSystemApp.Services
{
    public class CarRentalService
    {
        private readonly ICsvReader reader;
        private readonly ICsvWriter writer;
        private List<Car> cars;

        public CarRentalService(ICsvReader reader, ICsvWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            cars = this.reader.ReadCars();
        }

        public List<Car> GetCars() => this.cars;

        public Car GetCarById(int id) => this.cars.FirstOrDefault(c => c.Id == id);

        public void AddCar(Car car) => this.cars.Add(car);

        public void EditCar(int id, string make, string model, int year, string type, string status)
        {
            var car = this.GetCarById(id);
            if (car != null)
            {
                car.Make = make;
                car.Model = model;
                car.Year = year;
                car.Type = type;
                car.Status = status;
            }
        }

        public void RemoveCar(int id)
        {
            var car = this.GetCarById(id);
            if (car != null)
            {
                car.Status = "Removed";
            }
        }

        public void RentCar(int id, string renterName)
        {
            var car = GetCarById(id);
            if (car == null)
            {
                Console.WriteLine($"Error: No car with ID {id} found.");
                return;
            }

            if (car.Status != "Available")
            {
                Console.WriteLine($"Error: Car ID {id} is not available (Status = {car.Status}).");
                return;
            }

            car.Status = "Rented";
            car.CurrentRenter = renterName;
            Console.WriteLine($"Success: Car ID {id} has been rented to {renterName}.");
        }

        public void ReturnCar(int id)
        {
            var car = this.GetCarById(id);
            if (car != null && car.Status == "Rented")
            {
                car.Status = "Available";
                car.CurrentRenter = "";
            }
        }

        public void SaveChanges()
        {
            writer.WriteCars(cars);
        }
    }
}
