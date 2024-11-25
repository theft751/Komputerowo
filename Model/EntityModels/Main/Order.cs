using Domain.EntityModels.Additional.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        //Navigation properties

        public virtual Adress Adress { get; set; }
        public int AdressId { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}