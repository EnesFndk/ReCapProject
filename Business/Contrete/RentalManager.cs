using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            if (!CarDeliveryVerification(rental.CarId))
            {
                return new ErrorResult(Messages.CarNotRented);
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        private bool CarDeliveryVerification(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).OrderByDescending(r=>r.Id).FirstOrDefault();
            if (result == null || result.ReturnDate == null || result.ReturnDate.Date < DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);          
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalModified);            
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetailDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

    }
}
