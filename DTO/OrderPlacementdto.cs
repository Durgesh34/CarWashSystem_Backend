using Microsoft.AspNetCore.Mvc;

namespace CarWashSystem.DTO
{

    public class OrderPlacementDto
    {
    public int Id { get; set; }
      public string Name { get; set; }
      public DateTime scheduledatetime { get; set; }
      public string PickUpPoint { get; set; }
      public double TotalAmount { get; set; }

     public string WashingStatus { get; set; }
    public string CarModel { get; set; }

    public string CarNumber { get; set; }
    public int UserId { get; set; }
    public string WasherId  {get; set; }


}
  }

