using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
  public class OrderRepository : IOrder
  {
    private readonly OnDemandDbContext context;

    public OrderRepository(OnDemandDbContext context)
    {
      this.context = context;
    }

    public async Task<Order> CreateOrder(Order order)
    {
      await context.Orders.AddAsync(order);
      await context.SaveChangesAsync();
      return order;
    }

    public async Task<Order> DeleteOrder(int id)
    {
      var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
      if (order == null)
      {
        return null;
      }
      context.Orders.Remove(order);
      await context.SaveChangesAsync();
      return order;
    }

    public async Task<List<Order>> GetOrders()
    {
      return await context.Orders.ToListAsync();
    }
  }
}
