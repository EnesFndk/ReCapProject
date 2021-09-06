using DataAccess.Abstract;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Contrete
{
    public class InMemoryCarDal : IInMemoryCarDal
    {
        List<Car> _car;
        public  InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=2, ModelYear=2005, DailyPrice=20000, Description="Like a baby" },
                new Car{CarId=2, BrandId=2, ColorId=1, ModelYear=2015, DailyPrice=90000, Description="Like a flower" },
                new Car{CarId=3, BrandId=4, ColorId=3, ModelYear=2010, DailyPrice=70000, Description="Very Fast" },
                new Car{CarId=4, BrandId=5, ColorId=1, ModelYear=2012, DailyPrice=120000, Description="Very huge" },
                new Car{CarId=5, BrandId=2, ColorId=4, ModelYear=2021, DailyPrice=220000, Description="Strong and Fast" }
            };
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(car => car.CarId == id).ToList();
        }
        public List<Car> GetAll()
        {
            return _car;
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(car => car.CarId == car.CarId);
            _car.Remove(carToDelete);
        }
        
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(car => car.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        Car IInMemoryCarDal.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
