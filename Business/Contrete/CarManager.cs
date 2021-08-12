using Business.Abstract;
using DataAccess.Abstract;
using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Contrete
{
    public class CarManager : ICarManager
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }
        public Car GetById(int id)
        {
            return _cardal.Get(q => q.Id == id);
        }
        
        public void Add(Car car)
        {

            if (car.Description.Length<2)
            {
                throw new Exception("Araba ismi 2 karakterden küçük olamaz");
            }

            if (car.DailyPrice<=0)
            {
                throw new Exception("Araba fiyatı 0 veya 0'dan küçük olamaz");
            }
            _cardal.Add(car);

        }
        public void Delete(Car car)
        {
            _cardal.Delete(car);
        }
        public void Update(Car car)
        {
            _cardal.Update(car);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _cardal.GetAll(q => q.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _cardal.GetAll(q => q.ColorId == colorId).ToList();
        }
        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _cardal.GetCarDetails();
        }
    }
}
