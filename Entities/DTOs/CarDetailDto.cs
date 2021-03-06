using Core;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int brandId { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public int colorId { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public string  Description { get; set; }
        public List<CarImage> CarImage { get; set; }

    }
}
