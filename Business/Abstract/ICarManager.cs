using Core.Utilities.Results;
using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager 
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId );
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        //IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);
        //IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);

        //IResult AddTransactionalTest(Car car);
    }
}
