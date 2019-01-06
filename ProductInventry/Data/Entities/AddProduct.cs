using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProductInventry.Data.Entities
{
    public class AddProduct :BaseEntity
    {
        
      public string Name { get; set; }
      public int Price { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
