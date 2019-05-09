using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysEcommerce.BOL.Entities;

namespace ToysEcommerce.DAL.Contexts
{
    public class Context : DbContext
    {
        public Context() : base("CS1")
        {}
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
    }
}
