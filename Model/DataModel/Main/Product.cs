using Model.DataModel.Additional.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Main
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string AdditionalInfo { get; set; }
        public string Color { get; set; }
        public ProductType ProductType { get; set; } //dyscryminator
        public int Amount { get; set; }


        public int GuarantyTime { get; set; } //Months
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Navigation properties

        public int MainImageId { get; set; }
        public virtual MainProductImage MainImage { get; set; }

        public virtual  ICollection<BonusProductImage> BonusImages { get; set; } = new List<BonusProductImage>();

        public string Producer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [NotMapped]
        public Availability Availability

        {
            get =>
                Amount >= 1 ? Availability.Avabile : Availability.Unavabile;
        }
    }
}
 