using Core.DataAccess;
using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        public List<RentalDetailDto> GetRentalDetails();
    }
}
