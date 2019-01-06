using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventry.Data.Entities
{
    public class OrderProduct:BaseEntity
    {

        public Guid AddProductId { get; set; }
        public  Guid AddOrderId { get; set; }
        public int Quantity { get; set; }

        public AddProduct AddProduct { get; set; }
        public AddOrder AddOrder { get; set; }

       
    }
}
