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

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.Id = 3;
            rental.CarId = 1;
            rental.CustomerId = 1;
            rental.RentDate = new DateTime(2021, 08, 15);
            rental.ReturnDate = new DateTime(2021, 08, 17);
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);





            //ICustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //foreach (var cu in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(cu.UserId.ToString(), cu.CompanyName);
            //}
            //Customer customer = new Customer()
            //{
            //    UserId = 2,
            //    CompanyName = "Fındık Galeri"
            //};

            //customerManager.Add(customer);
            //Console.WriteLine();




            //10. Ders Ödev 1
            ////BURADA CarManageri Result işleminde temiz kod ile yaptık.
            //CarManager carManager = new CarManager(new EfCarDal());

            //var result = carManager.GetCarDetailDtos();
            //if (result.Success == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarName + " / " + car.DailyPrice);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            //--------------------------------------------------------------
            ////BURADA ColorManageri Result işleminde temiz kod ile yaptık.
            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //var result = colorManager.GetAll();
            //if (result.Success == true)
            //{
            //    foreach (var color in result.Data)
            //    {
            //        Console.WriteLine(color.Id + " / " + color.Name);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            //--------------------------------------------------------------
            ////BURADA BrandManager Result işleminde temiz kod ile yaptık.
            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            //var result = brandManager.GetAll();
            //if (result.Success == true)
            //{
            //    foreach (var brand in result.Data)
            //    {
            //        Console.WriteLine(brand.Id + " / " + brand.Name);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            //--------------------------------------------------------------







            //ColorCRUD();
            //BrandCRUD();
            //Join();
            //CarManagerAddNewCar();

        }

        //private static void ColorCRUD()
        //{
        //    IColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var c in colorManager.GetAll())
        //    {
        //        Console.WriteLine(c.Name, c.Id);
        //    }
        //    Color color = new Color()
        //    {
        //        Id = 1,
        //        Name = "Black"
        //    };

        //    colorManager.Add(color);
        //    Console.WriteLine();


        //    var c1 = colorManager.GetById(1);
        //    Console.WriteLine(c1.Name);

        //    c1.Name = "Mor";
        //    colorManager.Update(c1);
        //    var c2 = colorManager.GetById(1);
        //    Console.WriteLine(c2.Name);

        //    colorManager.Delete(c1);
        //    Console.WriteLine();
        //}

        //private static void BrandCRUD()
        //{
        //    IBrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var x in brandManager.GetAll())
        //    {
        //        Console.WriteLine(x.Name, x.Id);
        //    }
        //    Brand brand = new Brand()
        //    {
        //        Id = 5,
        //        Name = "Mercedes Lan Bu"
        //    };


        //    brandManager.Add(brand);
        //    Console.WriteLine();


        //    var x1 = brandManager.GetById(5);
        //    Console.WriteLine(x1.Name);

        //    x1.Name = "Bmw";
        //    brandManager.Update(x1);
        //    var x2 = brandManager.GetById(5);
        //    Console.WriteLine(x2.Name);

        //    brandManager.Delete(x2);
        //    Console.WriteLine();
        //}

        //private static void Join()
        //{
        //    ICarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetailDtos())
        //    {
        //        Console.WriteLine(car.BrandName + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
        //    }
        //}

        //private static void CarManagerAddNewCar()
        //{
        //    ICarManager carManager = new CarManager(new EfCarDal());

        //    var x = carManager.GetCarDetailDtos();

        //    foreach (var x in carManager.GetAll())
        //    {
        //        Console.WriteLine(x.Description, x.DailyPrice);
        //    }

        //    Car car = new Car()
        //    {
        //        Id = 4,
        //        BrandId = 2,
        //        ColorId = 1,
        //        DailyPrice = 100,
        //        ModelYear = 2001,
        //        Description = "Fiat"
        //    };
        //    carManager.Add(car);
        //    Console.WriteLine();
        //}
    }
}
