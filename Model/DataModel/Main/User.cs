using Model.DataModel.Additional.Common;
using System.ComponentModel.DataAnnotations;
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
        public UserType UserType { get; set; }
        //Navigation properties
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }
    }
}