using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Contrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Contrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join cr in context.Cars
                             on r.CarId equals cr.CarId
                             join cs in context.Customers
                             on r.CustomerId equals cs.UserId
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             join u in context.Users
                             on cs.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 BrandName = br.BrandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
    
}
