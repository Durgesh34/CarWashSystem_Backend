using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
  public class CarRepository : ICar
  {
    private readonly OnDemandDbContext context;

    public CarRepository(OnDemandDbContext context)
    {
      this.context = context;
    }

    public async Task<Car> CreateCar(Car car)
    {
      await context.Cars.AddAsync(car);
      await context.SaveChangesAsync();
      return car;
    }

    public async Task<Car> DeleteCar(int id)
    {
      var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
      if (car == null)
      {
        return null;
      }
      context.Cars.Remove(car);
      await context.SaveChangesAsync();
      return car;
    }

    public async Task<List<Car>> GetCar()
    {
      return await context.Cars.ToListAsync();
    }
  }
}
