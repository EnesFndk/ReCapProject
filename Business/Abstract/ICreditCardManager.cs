using Core.Utilities.Results;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardManager
    {
        IDataResult<CreditCard> GetById(int id);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);

        IResult Add(CreditCard creditCard);

        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
    }
}
