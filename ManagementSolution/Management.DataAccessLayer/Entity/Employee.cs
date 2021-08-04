using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.DataAccessLayer.Entity
{
    public class Employee : Audit, IEntity, ISoftDelete
    {
        public Employee()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int No { get; set; }
        public bool IsDeleted { get; set; }
    }
}
