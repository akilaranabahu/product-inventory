using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventry.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductInventry.Data
{
    public class ProductContext :DbContext
    {
       

        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        public DbSet<AddProduct> AddProducts { get; set; }
        public DbSet<AddOrder> AddOrders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ListOrder> ListOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=(localdb)\\ProjectsV13;Database=ProductInventryDB;Integrated Security=true;MultipleActiveResultSets=true;"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AddProduct>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<AddOrder>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ListOrder>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
            });

        }
    }
}


