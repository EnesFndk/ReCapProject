using Business.Abstract;
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

        public void Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                throw new Exception("Araba ismi 2 karakterden küçük olamaz");
            }

            if (brand.Id <= 0)
            {
                throw new Exception("Araba fiyatı 0 veya 0'dan küçük olamaz");
            }
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.Id == brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
