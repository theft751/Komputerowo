using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Main
{
    public class BonusProductImage
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public string ImageType { get; set; }
        public byte[] ImageData { get; set; }
        
        //Navigation properties
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
