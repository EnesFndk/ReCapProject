using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Contrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color,ReCapContext>, IColorDal
    {
        
    }
}
