using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventry.ViewModels
{
    public class SampleModel
        
    {
        public List<SaveQuantityViewModels> SaveQuantityViews { get; set; }
    }

    public class SaveQuantityViewModels
    {
        public int Quantity { get; set; }
        public virtual Guid Id { get; set; }
    }
}