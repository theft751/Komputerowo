using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public class BonusProductImage
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Type { get; set; }
        public byte[] Data { get; set; }
        
        //Navigation properties
        public virtual Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}
