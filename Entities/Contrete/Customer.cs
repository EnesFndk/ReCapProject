using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Contrete
{
    public class Customer : IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
