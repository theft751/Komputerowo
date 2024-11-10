using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityModels.Main
{
    public class MainProductImage
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public string ImageType { get; set; }
        public byte[] ImageData { get; set; }

        //Navigation property
        public virtual Product Product { get; set; }

    }
}