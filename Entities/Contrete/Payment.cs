using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contrete
{
    public class Payment:IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
    }
}
