using Florist.DAL.Entity;
using Florist.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Florist.DataAccessLayer.Context
{
    public class FloristDatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// veri tabanı bağlantı adresinin tanımlandığı metot  
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=FloristDatabase;Uid=username;Pwd=password;");
                //Enter your MySQL username and password 
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<FlowerCategory> FlowerCategories { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
// M. Entity framework core --> veri tabanı baplantısı için kütüphane
//m.e.f.c.tools -->komut satırında migration işlemleri için kütüphane
//mysql.e.f.c. --> mysql veri tabanına bağlantı için gerekli kütüphane