using CarWashSystem.Data;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
    public class SQLAddonRepository : IAddon
    {
        private readonly OnDemandDbContext context;

        public SQLAddonRepository(OnDemandDbContext context) 
        {
            this.context = context;
        }
        public async Task<AddOn> CreateAddOn(AddOn addon)
        {
           await context.AddOns.AddAsync(addon);
            await context.SaveChangesAsync();
            return addon;
        }

        public async Task<AddOn> DeleteAddOn(int id)
        {
            var addon = await context.AddOns.FirstOrDefaultAsync(x => x.Id == id);
            if (addon == null)
            {
                return null;
            }
            context.AddOns.Remove(addon);
            await context.SaveChangesAsync();
            return addon;
        }

        public async Task<List<AddOn>> GetAddOn()
        {
            return await context.AddOns.ToListAsync();
        }

        public async Task<AddOn> GetAddOnById(int id)
        {
             return await context.AddOns.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AddOn> UpdateAddOn(int id, AddOn addon)
        {
            var existingdata = await context.AddOns.FirstOrDefaultAsync(x => x.Id == id);
            if (addon == null)
            {
                return null;
            }

            existingdata.Name = addon.Name;
            existingdata.Description = addon.Description;
            existingdata.Price = addon.Price;

            await context.SaveChangesAsync();
            return existingdata;
        }
    }
}
