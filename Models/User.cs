using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CarWashSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }= string.Empty;

        [Required(ErrorMessage = "Password is required")]

        //public string Password { get; set; }=string.Empty;
        public string Address { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [JsonIgnore]
        public IEnumerable<Payment> Payments { get; set; }

        [JsonIgnore]
        public IEnumerable<Car> Cars { get; set; }

        [JsonIgnore]
        public IEnumerable<Order> Order { get; set; }
    }
}
