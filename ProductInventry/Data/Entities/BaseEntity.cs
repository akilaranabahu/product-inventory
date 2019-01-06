using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventry.Data.Entities
{
    public class BaseEntity
    {
        [Column(Order = 1)]
        public virtual Guid Id { get; set; }
    }
}
