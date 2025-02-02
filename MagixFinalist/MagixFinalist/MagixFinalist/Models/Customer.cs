using System.ComponentModel.DataAnnotations;

namespace MagixFinalist.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
