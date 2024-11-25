using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Main
{
    public class Producer
    {
        [Key]
        public  int Id { get; set; }
        public string Name { get; set; }

        //Public navigation properties
        public virtual ICollection<Product> Products { get; set; }
    }
}
