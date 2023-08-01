using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarWashSystem.Models
{
    public class AddOn
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { set; get; }


        
    }
}
