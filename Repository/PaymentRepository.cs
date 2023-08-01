using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
  public class PaymentRepository : IPayment
  {
    private readonly OnDemandDbContext context;

    public PaymentRepository(OnDemandDbContext context)
    {
      this.context = context;
    }

    public async Task<Payment> CreatePayment(Payment pay)
    {
      await context.Payments.AddAsync(pay);
      await context.SaveChangesAsync();
      return pay;
    }

    public async Task<Payment> DeletePayment(int id)
    {
      var pay = await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
      if (pay == null)
      {
        return null;
      }
      context.Payments.Remove(pay);
      await context.SaveChangesAsync();
      return pay;
    }

    public async Task<List<Payment>> GetPayments()
    {
      return await context.Payments.ToListAsync();
    }
  }
}
