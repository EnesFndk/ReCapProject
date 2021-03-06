using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
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
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 15)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(q => q.CarId == id), Messages.CarsListed);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarIdExist(car.CarId),
                CheckIfCarNameExist(car.Description));

            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);

            return new SuccessResult(Messages.CarModified);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(q => q.brandId == brandId).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(q => q.colorId == colorId).ToList());
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        private IResult CheckIfCarIdExist(int carId)
        {
            var result = _carDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarNotExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExist(string name)
        {
            var result = _carDal.GetAll(c => c.Description == name).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarNotExist);
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailPageById(int id)
        {
            if (_carDal.GetCarDetails(c => c.CarId == id) != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id), Messages.RecordFound);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.IdInvalid);
        }

        //public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == colorName));
        //}

        //public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brandName));
        //}


        //[TransactionScopeAspect]
        //public IResult AddTransactionalTest(Car car)
        //{
        //    _carDal.Update(car);
        //    _carDal.Add(car);
        //    return new SuccessResult(Messages.CarModified);
        //}
    }
}
