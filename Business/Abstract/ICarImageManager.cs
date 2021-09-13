using Core.Utilities.Results;
using Entities.Contrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageManager
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetCarImageById(int id);
        IDataResult<List<CarImage>> GetAllImageByCarId(int id);
        IResult Add(IFormFile fromfile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile fromfile, CarImage carImage);
        
    }
}
