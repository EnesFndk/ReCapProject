using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        public List<CarDetailDto> GetAllCarsDetails(Expression<Func<Car, bool>> filter = null);

        public List<Car> GetById();
    }
}
