using Core.DataAccess;
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
        public List<CarDetailDto> GetCarDetails();
    }
}
