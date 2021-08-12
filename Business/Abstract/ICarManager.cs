using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager 
    {
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetCarsByBrandId(int brandId );
        List<Car> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetailDtos();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
