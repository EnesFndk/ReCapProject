using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contrete
{
    public class BrandManager : IBrandManager
    {
        IBrandDal _brandDal;
        
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }

            return new ErrorResult(Messages.BrandAdded);

            _brandDal.Add(brand);
        }

        public IResult Delete(Brand brand)
        {
            return new ErrorResult(Messages.BrandDeleted);

            _brandDal.Delete(brand);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            return new ErrorResult(Messages.BrandModified);

            _brandDal.Update(brand);
        }
    }
}
