using Device.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.Context
{
    /// <summary>
    /// Veri tabanı ile bağlantı kurulan ve işlemleri barındıran kısım --> Context
    /// Eklenmesi gereken kütüphaneler;
    ///M.EntityFrameworkCore --> veri tabanı baplantısı için kütüphane
    ///M.EFC.Tools -->komut satırında migration işlemleri için kütüphane
   /// Mysql.EFC --> mysql veri tabanına bağlantı için gerekli kütüphane
    /// </summary>
    public class DeviceDatabaseContext : DbContext
    {
        /// <summary>
        /// Veritabanı bağlantı adresinin tanımlandığı metod
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=DeviceDatabase;;Uid=username;Pwd=password;");
            //Enter your MySQL username and password 
        }

        /// <summary>
        ///Configuration klasöründeki içerikler normalde onmodelcreating metoduna yazılır
        ///Yazmak yerine assembly(birleştir) metodu ile hepsini dışarıdan dahil ettik
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Veri tabanında sorgu işlemlerinde kullanmak için gereken bağlantı --> DbSet
        /// </summary>
        public DbSet<Tv> Tvs { get; set; }
        public DbSet<Tel> Tels { get; set; }
    }
}
