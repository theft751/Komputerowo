using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppModel
{
    public class BasketElement()
    {
        public int ProductId { get; set; } 
        public int Amount { get; set; }
    }
}
