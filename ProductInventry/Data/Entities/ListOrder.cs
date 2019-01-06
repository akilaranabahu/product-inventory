using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventry.Data.Entities
{
    public class ListOrder:BaseEntity
    {
     public Guid OrderID { get; set; }
     public int TotalPrice { get; set; }

    }
}
