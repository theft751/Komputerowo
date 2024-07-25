using Model.DataModel.Enums.Main;
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
        public int Amount 
        {
            get =>Amount;
            set 
            {
                if (value == 0 && Availability == Availability.Avabile)
                { 
                    
                    Availability = Availability.CurrentlyNotAvabile;
                    Amount = value;
                }
                else if (value < 0)
                    Amount = 0;
                else
                    Amount = value;
            }
        }
        public Availability Availability { get; set; }
        public int GuarantyTime { get; set; } //Months
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Navigation properties

        public int MainImageId { get; set; }
        public MainProductImage MainImage { get; set; }
        
        public ICollection<BonusProductImage> BonusImages { get; set; }

        public Producer Producer { get; set; }
        public int ProducerId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
 