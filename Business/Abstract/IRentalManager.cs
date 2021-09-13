using Core.Utilities.Results;
using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);

        IDataResult<List<RentalDetailDto>> GetRentalDetailDtos();
        IDataResult<Rental> GetLastRentalByCarId(int carId);
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
