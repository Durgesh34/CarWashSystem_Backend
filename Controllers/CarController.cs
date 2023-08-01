using CarWashSystem.Data;
using CarWashSystem.DTO;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using CarWashSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarController : ControllerBase
  {

    private readonly ICar carrepository;

    public CarController(ICar carrepository)
    {

      this.carrepository = carrepository;
    }



    [HttpPost]
    public async Task<ActionResult<IEnumerable<Car>>> PostCar(Cardto cardto)
    {

      var car = new Car()
      {
        CarModel = cardto.CarModel,
        CarType = cardto.CarType,
        UserId = cardto.UserId
      };
      car = await carrepository.CreateCar(car);
      return Ok(car);
    }

    /*
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCar()
    {
      var cars = await carrepository.GetCar();

      var cardto = new List<Cardto>();

      foreach (var car in cars)
      {

        cardto.Add(new Cardto()
        {
          Id = cardto.Id,
          CarModel = cardto.CarModel,
          CarType = cardto.CarType,
          UserId = cardto.UserId
        });
      }

      return Ok(cars);
    */




  }
}
