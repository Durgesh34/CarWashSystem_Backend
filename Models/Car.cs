using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CarWashSystem.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Car Model is required")]
        [DisplayName("Car Model")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Car Type is required")]
        [DisplayName("Car Type")]
        public string CarType { get; set; }

        [DisplayName("Car Image")]
        public string? CarImg { get; set; }

        public int UserId { get; set; }

      //  [JsonIgnore]
       // public User User { get; set; }

        //public IEnumerable<Order> Cars { get; set;}
    }
}
