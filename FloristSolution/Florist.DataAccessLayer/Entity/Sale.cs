using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.DataAccessLayer.Entity
{
    public class Sale : Audit, IEntity, ISoftDelete
    {
        public Sale()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
