using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventry.Data.Entities;

namespace ProductInventry.ViewModels
{
    public class SaveOrderViewModel
    {
        public List<AddProduct> SaveOrder { get; set; }
        
        public List<OrderProduct> SaveQuantity { get; set; }

      


        public SaveOrderViewModel(List<AddProduct> _saveorder, List<OrderProduct> _savequantity)
        {
            SaveOrder = _saveorder;
            SaveQuantity = _savequantity;
        }

        
    }
}
