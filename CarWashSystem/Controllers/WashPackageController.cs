using CarWashSystem.DTO;
using CarWashSystem.Models;
using CarWashSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWashSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WashPackageController : ControllerBase
    {
        private readonly IWashPackage washpackagerepository;

        public WashPackageController(IWashPackage washpackagerepository) 
        {
            this.washpackagerepository = washpackagerepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetWashPackage()
        {
            var washpackages = await washpackagerepository.GetWashPackage();

            var washpackagedto = new List<WashPackagedto>();
            foreach (var wash in washpackages)
            {

                washpackagedto.Add(new WashPackagedto()
                {
                    Id = wash.Id,
                    Name = wash.Name,
                    Description = wash.Description,
                    Price = wash.Price
                });
            }

            return Ok(washpackagedto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetWashPackageById(int id)
        {


            var washpackage = await washpackagerepository.GetWashPackageById(id);
            if (washpackage == null)
            {
                return NotFound();
            }
            var washpackagedto = new WashPackagedto()
            {
                Id = washpackage.Id,
                Name = washpackage.Name,
                Description = washpackage.Description,
                Price = washpackage.Price
            };

            return Ok(washpackagedto);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<AddOn>>> PostWashPackage(CreateWashPackage createWashPackage)
        {

            var washpackage = new WashPackage()
            {
                Name = createWashPackage.Name,
                Description = createWashPackage.Description,
                Price = createWashPackage.Price
            };
            washpackage = await washpackagerepository.CreateWashPackage(washpackage);
            return Ok(washpackage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, CreateAddondto addonUpdatedto)
        {
            var washpackage = new WashPackage()
            {
                Name = addonUpdatedto.Name,
                Description = addonUpdatedto.Description,
                Price = addonUpdatedto.Price,

            };

            washpackage = await washpackagerepository.UpdateWashPackage(id, washpackage);

            if (washpackage == null)
            {
                return NotFound();
            }
            else
            {
                washpackage.Name = addonUpdatedto.Name;
                washpackage.Description = addonUpdatedto.Description;
                washpackage.Price = addonUpdatedto.Price;

            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {

            var washpackage = await washpackagerepository.DeleteWashPackage(id);
            if (washpackage == null)
            {
                return NotFound();
            }
            // no asyn method for remove so no await for remove

            return Ok(washpackage);
        }
    }
}
