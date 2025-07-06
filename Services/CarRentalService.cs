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
        
        public List<Car> Cars { get; set; }
        private List<Customer> Customers { get; set; }
        public CarRentalService(ICsvReader reader, ICsvWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.Cars = this.reader.ReadCars();
            this.Customers = new List<Customer>();
        }

        public List<Car> GetCars() => this.Cars;

        public Car GetCarById(int id) => this.Cars.FirstOrDefault(c => c.Id == id);

        public void AddCar(Car car) => this.Cars.Add(car);
        public void AddCustomer(Customer customer) => this.Customers.Add(customer);

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

        public void RentCar(int id, string renterName, DateTime date)
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
            Customer rentner = new Customer(Customers.Count + 1, renterName, "");
            this.AddCustomer(rentner);
            car.CurrentRenter = rentner.Name;
            Console.WriteLine($"Success: Car ID {id} has been rented to {rentner.Name}.");
            Rent rent = new Rent(car.Id, rentner.Id, date);
            rentner.AssignRent(rent);
        }

        public void ReturnCar(int id)
        {
            var car = this.GetCarById(id);
            if (car != null && car.Status == "Rented")
            {
                car.Status = "Available";
                car.CurrentRenter = null;
            }
        }

        public void SaveChanges()
        {
            writer.WriteCars(cars);
        }
    }
}
