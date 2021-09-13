using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Contrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Contrete
{
    public class CarImageManager : ICarImageManager
    {
        ICarImageDal _carImageDal;
        IHostingEnvironment _hostingEnvironment;

        public CarImageManager(ICarImageDal carImageDal, IHostingEnvironment hostingEnvironment)
        {
            _carImageDal = carImageDal;
            _hostingEnvironment = hostingEnvironment;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile fromfile, CarImage carImage)
        {

            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileUpload.Add(fromfile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;


            var fullPath = webRootPath + "/Images/" + carImage.ImagePath;
            var result = FileUpload.Delete(fullPath);
            if (result)
{
                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }
            return new ErrorResult("Resim silinemedi");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsImageListed);
        }

        public IDataResult<List<CarImage>> GetAllImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageOfNull(carId).Data, Messages.RecordsListed);
        }

        public IDataResult<List<CarImage>> GetCarImageById(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageOfNull(carId));
            if (result !=null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>
                (CheckIfCarImageOfNull(carId).Data, Messages.CarsImageListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id), Messages.ImageFound);
        }

        

        public IResult Update(IFormFile formfile, CarImage carImage)
        {
            var carImg = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            string webRootPath = _hostingEnvironment.WebRootPath;


            var fullPath = webRootPath + "/Images/" + carImg.ImagePath;

            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImg.Date = DateTime.Now;
            carImg.ImagePath = FileUpload.Add(formfile);
            FileUpload.Delete(fullPath);
            _carImageDal.Update(carImg);
            return new SuccessResult();
        }


        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageOfNull(int carId)
        {
            try
            {
                string path = @"default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>() {
                        new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now }
                    };
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
    }
}
