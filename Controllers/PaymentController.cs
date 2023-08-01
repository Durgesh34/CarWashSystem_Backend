using CarWashSystem.Data;
using CarWashSystem.DTO;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using CarWashSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CarWashSystem.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentController : ControllerBase
  {

    private readonly IPayment payrepository;

    public PaymentController(IPayment payrepository)
    {

      this.payrepository = payrepository;
    }


    [HttpPost]
    public async Task<ActionResult<IEnumerable<Payment>>> PostPayment(Payment pay)
    {

      var pays = new Payment()
      {  
        CardHolderName = pay.CardHolderName,
        CardType = pay.CardType,
        CardNumber = pay.CardNumber,
        CVV = pay.CVV,
        TotalAmount = pay.TotalAmount,
        ExpiryDate = pay.ExpiryDate,
        UserId = pay.UserId
      };
      pays = await payrepository.CreatePayment(pays);
      return Ok(pays);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayment()
    {
      var payments = await payrepository.GetPayments();
      return Ok(payments);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Payment>> DeletePayment(int id)
    {
      var deletedPayment = await payrepository.DeletePayment(id);

      if (deletedPayment == null)
      {
        return NotFound();
      }

      return Ok(deletedPayment);
    }

  }
}
