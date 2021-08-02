using ApplicationCore.Entity;
using Florist.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.DataAccessLayer.Entity
{
    public class Flower : Audit, IEntity, ISoftDelete
    {
        public Flower()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Specification { get; set; }
        public bool IsDeleted { get; set; }
        public int FlowerCategoryId { get; set; }
        public FlowerCategory FlowerCategoryFK { get; set; }
    }
}
