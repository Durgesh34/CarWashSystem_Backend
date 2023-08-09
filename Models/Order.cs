using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CarWashSystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Schedule Date Required")]
        [DisplayName("Schedule Date")]
        public DateTime scheduledatetime { get; set; }

        [Required(ErrorMessage = "Pickup Point Required")]
        [DisplayName("Pickup Point")]
        public string PickUpPoint { get; set; }
        public string? WashingStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public double TotalAmount { get; set; }

        public string? CarModel { get; set; }

        public string? CarNumber { get; set; }

   
        public User? User { get; set; }
        public int? UserId { get; set; }

        public string? WasherId { get; set; }
   
    public Car? Car { get; set; }
        public int? CarId { get; set; }

        public WashPackage? WashPackage { set; get; }
        public int? WashPackageId { get; set; }
    }
}
