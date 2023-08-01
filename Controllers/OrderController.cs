using CarWashSystem.DTO;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using CarWashSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWashSystem.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly IOrder orderrepository;

    public OrderController(IOrder orderrepository)
    {
      this.orderrepository = orderrepository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderPlacementDto>>> GetOrder()
    {
      var orders = await orderrepository.GetOrders();

      var orderdto = new List<OrderPlacementDto>();
      foreach (var order in orders)
      {
        orderdto.Add(new OrderPlacementDto()
        {
          Id = order.Id,
          Name = order.Name,
          scheduledatetime = order.scheduledatetime,
          PickUpPoint = order.PickUpPoint,
          TotalAmount = order.TotalAmount,
          CarModel = order.CarModel,
          CarNumber = order.CarNumber,
          UserId = order.UserId.HasValue ? (int)order.UserId : 0 // Or any default value you prefer
        });
      }

      return Ok(orderdto);
    }



    [HttpPost]
    public async Task<ActionResult<IEnumerable<Order>>> PostOrder(OrderPlacementDto order)
    {

      var orders = new Order()
      {
        Name = order.Name,
        scheduledatetime = order.scheduledatetime,
        PickUpPoint = order.PickUpPoint,
        TotalAmount = order.TotalAmount,
        UserId = (int)order.UserId,
        CarModel = order.CarModel,
        CarNumber = order.CarNumber,
      };
      orders = await orderrepository.CreateOrder(orders);
      return Ok(orders);
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult> DeleteOrder(int id)
    {

      var order = await orderrepository.DeleteOrder(id);
      if (order == null)
      {
        return NotFound();
      }
      // no asyn method for remove so no await for remove

      return Ok(order);
    }


  }
}



















    



