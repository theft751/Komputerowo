using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppModel
{
    public class RealisedOrder
    {
        public DateTime RealisationDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string Number { get; set; }
    }
}
