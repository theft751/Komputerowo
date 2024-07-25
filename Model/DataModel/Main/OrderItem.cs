using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Main
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int amount { get; set; }

        //Navigation properties
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
