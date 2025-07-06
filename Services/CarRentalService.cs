using CarRentalSystemApp.Interfaces;
using CarRentalSystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace CarRentalSystemApp.Services
{
    public class CarRentalService
    {
        private readonly ICsvReader<Car> carReader;
        private readonly ICsvWriter<Car> carWriter;
        private readonly ICsvReader<Customer> customerReader;
        private readonly ICsvWriter<Customer> customerWriter;


        public List<Car> Cars { get; set; }
        private List<Customer> Customers { get; set; }
        public CarRentalService(ICsvReader<Car> carReader, ICsvWriter<Car> carWriter, 
            ICsvReader<Customer> customerReader, 
            ICsvWriter<Customer> customerWriter)
        {
            this.carReader = carReader;
            this.carWriter = carWriter;
            this.customerReader = customerReader;
            this.customerWriter = customerWriter;
            this.Cars = this.carReader.ReadItems();
            this.Customers = this.customerReader.ReadItems();
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
            Customer rentner = Customers.Find(c => c.Name.Equals(renterName, StringComparison.OrdinalIgnoreCase));
            if (rentner == null)
            {
                rentner = new Customer(Customers.Count + 1, renterName, "");
            }
            
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
            carWriter.WriteItems(Cars);
            customerWriter.WriteItems(Customers);
        }
    }
}
