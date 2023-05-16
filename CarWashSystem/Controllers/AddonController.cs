using CarWashSystem.Data;
using CarWashSystem.DTO;
using CarWashSystem.Models;
using CarWashSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddonController : ControllerBase
    {
        
        private readonly IAddon addonrepository;

        public AddonController( IAddon addonrepository)
        {
            
            this.addonrepository = addonrepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetAddon()
        {
            var addons = await addonrepository.GetAddOn();
            
            var addondto = new List<Addondto>();
            foreach (var addon in addons)
            {

                addondto.Add(new Addondto()
                {
                    Id = addon.Id,
                    Name = addon.Name,
                    Description = addon.Description,
                    Price = addon.Price
                });
            }

            return Ok(addondto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetAddonById(int id)
        {
          

            var addon = await addonrepository.GetAddOnById(id);
            if (addon == null)
            {
                return NotFound();
            }
            var addondto = new Addondto()
            {
                Id = addon.Id,
                Name = addon.Name,
                Description = addon.Description,
                Price = addon.Price
            };

            return Ok(addondto);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<AddOn>>> PostAddon(CreateAddondto createaddondto)
        {
            
            var addon = new AddOn()
            {
                Name = createaddondto.Name,
                Description = createaddondto.Description,
                Price = createaddondto.Price
            };
            addon = await addonrepository.CreateAddOn(addon);
            return Ok(addon);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAddon(int id, CreateAddondto addonUpdatedto)
        {
            var addon = new AddOn()
            {
                Name = addonUpdatedto.Name,
                Description = addonUpdatedto.Description,
                Price = addonUpdatedto.Price,
               
            };

            addon = await addonrepository.UpdateAddOn(id, addon);

            if (addon == null)
            {
                return NotFound();
            }
            else
            {
                addon.Name = addonUpdatedto.Name;
                addon.Description = addonUpdatedto.Description;
                addon.Price = addonUpdatedto.Price;
                
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteAddon(int id)
        {
            
            var addon = await addonrepository.DeleteAddOn(id);
            if (addon == null)
            {
                return NotFound();
            }
            // no asyn method for remove so no await for remove

            return Ok(addon);
        }
    }
}
