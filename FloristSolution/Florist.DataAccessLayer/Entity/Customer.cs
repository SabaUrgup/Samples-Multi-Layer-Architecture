using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.DataAccessLayer.Entity
{
    public class Customer : Audit, IEntity, ISoftDelete
    {
        public Customer()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int TelNo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
