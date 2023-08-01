using CarWashSystem.Models;

namespace CarWashSystem.Interface
{
  public interface IOrder
  {
    Task<Order> CreateOrder(Order order);

    Task<List<Order>> GetOrders();
    Task<Order> DeleteOrder(int id);
  }
}
