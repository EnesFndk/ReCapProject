using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contrete
{
    public class CarImage:IEntity
    {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
