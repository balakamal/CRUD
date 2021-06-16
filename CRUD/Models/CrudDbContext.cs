using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD.Models
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext() : base("MyCon")
        {

        }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}