using CarWashSystem.Models;

namespace CarWashSystem.Interface
{
  public interface ICar
  {

    Task<List<Car>> GetCar();
   // Task<AddOn> GetAddOnById(int id);
    Task<Car> CreateCar(Car car);
   
    Task<Car> DeleteCar(int id);
  }
}
