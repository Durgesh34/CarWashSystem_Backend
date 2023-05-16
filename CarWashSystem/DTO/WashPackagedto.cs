using System.ComponentModel.DataAnnotations;

namespace CarWashSystem.DTO
{
    public class WashPackagedto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
