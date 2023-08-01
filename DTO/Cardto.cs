using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarWashSystem.DTO
{
  public class Cardto
  {

    [Key]
    public int Id { get; set; }

    public string CarModel { get; set; }

    public string CarType { get; set; }

    public int UserId { get; set; }
  }
}

