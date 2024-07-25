using Model.DataModel.Enums.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Main
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        //Navigation properties

        public Adress Adress { get; set; }
        public int AdressId { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}