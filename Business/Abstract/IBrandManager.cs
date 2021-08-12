using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandManager
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
