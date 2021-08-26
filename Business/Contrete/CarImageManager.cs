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

        public IDataResult<CarImage> GetById(int carImagedId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ca => ca.Id == carImagedId));
        }

        public IResult Update(IFormFile formfile, CarImage carImage)
        {
            var carImg = _carImageDal.Get(x => x.Id == carImage.Id);
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
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }
    }
}
