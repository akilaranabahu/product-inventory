using ProductInventry.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventry.Data
{
    public class ProductSeeder
    {
        private readonly ProductContext _ctx;

        public ProductSeeder(ProductContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            //if (!_ctx.AddProducts.Any())
            

               
            }


        }
    }

