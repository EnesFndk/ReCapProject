using Core.DataAccess;
using Core.Entities.Contrete;
using Core.Utilities.Results;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
