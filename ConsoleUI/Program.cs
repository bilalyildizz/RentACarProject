using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ResultTest();
            

            Customer customer1 = new Customer() {CustomerId=1, UserId = 1, CompanyName = "Google" };
            Customer customer2 = new Customer() { CustomerId = 2, UserId = 2, CompanyName = "Facebook" };
            Customer customer3 = new Customer() { CustomerId = 3, UserId = 3, CompanyName = "Apple" };

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(customer2);
            result = customerManager.Add(customer3);
            result = customerManager.Add(customer1);
            var result1 = customerManager.GetAll();

            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.CompanyName);

            }

        }

        private static void ResultTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 1538, DailyPrice = 78, Description = "Fourth" };
            var result = carManager.Add(car1);
            Console.WriteLine(result.Success);


            var result1 = carManager.GetAll();
            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.Description);
            }
        }

    }
}
