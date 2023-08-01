using CarWashSystem.Models;

namespace CarWashSystem.Interface
{
  public interface IPayment
  {
    Task<Payment> CreatePayment(Payment pay);
    Task<List<Payment>> GetPayments();

    Task<Payment> DeletePayment(int id);
  }
}
