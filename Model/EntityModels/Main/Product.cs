using Domain.EntityModels.Additional.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public abstract class Product
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
        public string Producer { get; set; }

        //Navigation properties

        public int MainImageId { get; set; }
        public virtual MainProductImage MainImage { get; set; }

        public virtual  ICollection<BonusProductImage> BonusImages { get; set; } = new List<BonusProductImage>();

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        [NotMapped]
        public Availability Availability

        {
            get =>
                Amount >= 1 ? Availability.Avabile : Availability.Unavabile;
        }
        [NotMapped]
        public int AverageRate { get => Reviews.Count == 0 || Reviews == null ? 0 : Reviews.Sum(x => x.Rate) / Reviews.Count; }
    }
}
 