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
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RealisationDate {get; set; }
        //Navigation properties

        public virtual OrderAdress Adress { get; set; }
        public int AdressId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}