using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Main
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ReleaseDate { get; set; }

        [Range(1, 10, ErrorMessage = "This rate must be value between 1 and 10")]
        public int Rate { get; set; }

        //Navigation properties
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
