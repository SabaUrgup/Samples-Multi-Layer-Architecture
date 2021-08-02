using ApplicationCore.Entity;
using Florist.DataAccessLayer.Entity;
using System.Collections.Generic;

namespace Florist.DAL.Entity
{
    public class FlowerCategory : Audit, IEntity, ISoftDelete
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Flower> Flowers { get; set; }

    }
}
