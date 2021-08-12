using Business.Abstract;
using Business.Contrete;
using DataAccess.Contrete;
using DataAccess.Contrete.EntityFramework;
using Entities.Contrete;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            

            //ColorCRUD();
            //BrandCRUD();
            //Join();
            //CarManagerAddNewCar();

        }

        private static void ColorCRUD()
        {
            IColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var c in colorManager.GetAll())
            {
                Console.WriteLine(c.Name, c.Id);
            }
            Color color = new Color()
            {
                Id = 1,
                Name = "Black"
            };

            colorManager.Add(color);
            Console.WriteLine();


            var c1 = colorManager.GetById(1);
            Console.WriteLine(c1.Name);

            c1.Name = "Mor";
            colorManager.Update(c1);
            var c2 = colorManager.GetById(1);
            Console.WriteLine(c2.Name);

            colorManager.Delete(c1);
            Console.WriteLine();
        }

        private static void BrandCRUD()
        {
            IBrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var x in brandManager.GetAll())
            {
                Console.WriteLine(x.Name, x.Id);
            }
            Brand brand = new Brand()
            {
                Id = 5,
                Name = "Mercedes Lan Bu"
            };


            brandManager.Add(brand);
            Console.WriteLine();


            var x1 = brandManager.GetById(5);
            Console.WriteLine(x1.Name);

            x1.Name = "Bmw";
            brandManager.Update(x1);
            var x2 = brandManager.GetById(5);
            Console.WriteLine(x2.Name);

            brandManager.Delete(x2);
            Console.WriteLine();
        }

        private static void Join()
        {
            ICarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.BrandName + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }

        private static void CarManagerAddNewCar()
        {
            ICarManager carManager = new CarManager(new EfCarDal());

            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description, x.DailyPrice);
            }

            Car car = new Car()
            {
                Id = 4,
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 100,
                ModelYear = 2001,
                Description = "Fiat"
            };
            carManager.Add(car);
            Console.WriteLine();
        }
    }
}
