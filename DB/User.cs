using System.ComponentModel.DataAnnotations;

namespace DB
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DesiredProduct> DesiredProducts { get; set; } = new List<DesiredProduct>();
    }
}
