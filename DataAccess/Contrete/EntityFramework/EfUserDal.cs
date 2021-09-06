using Core.DataAccess.EntityFramework;
using Core.Entities.Contrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Contrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.UserId
                             select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, OperationClaimName = operationClaim.OperationClaimName };
                return result.ToList();
            }
        }
    }
}
