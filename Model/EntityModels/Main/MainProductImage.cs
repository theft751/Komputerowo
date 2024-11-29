using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public class MainProductImage
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Type { get; set; }
        public byte[] Data { get; set; }

        //Navigation property
        public virtual Product? Product { get; set; }

    }
}