using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.DataAccessLayer.DataTransferObject.FlowerDTO
{
    public class FlowerAddDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Specification { get; set; }
        public int FlowerCategoryId { get; set; }
    }
}
