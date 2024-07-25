using System.ComponentModel.DataAnnotations;
using Model.DataModel.Enums;

namespace Model.DataModel.Main
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        //Navigation properties
        public virtual ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Adress> Adresses { get; set; }
    }
}