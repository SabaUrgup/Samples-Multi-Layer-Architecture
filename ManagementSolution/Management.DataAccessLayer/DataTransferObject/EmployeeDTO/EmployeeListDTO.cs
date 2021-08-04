using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.DataAccessLayer.DataTransferObject.EmployeeDTO
{
    public class EmployeeListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int No { get; set; }
    }
}
