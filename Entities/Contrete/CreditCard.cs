using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contrete
{
    public class CreditCard:IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int Cvv { get; set; }
        public string CardType { get; set; }
        public int CardLimit { get; set; }
    }
}
