using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
    }
}
