using CarWashSystem.Data;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
    public class SQLWashPackageRepository : IWashPackage
    {
        private readonly OnDemandDbContext context;

        public SQLWashPackageRepository(OnDemandDbContext context) 
        {
            this.context = context;
        }
        public async Task<WashPackage> DeleteWashPackage(int id)
        {
            var washPackage = await context.WashPackages.FirstOrDefaultAsync(x => x.Id == id);
            if (washPackage == null)
            {
                return null;
            }
            context.WashPackages.Remove(washPackage);
            await context.SaveChangesAsync();
            return washPackage;
        }

        public async Task<List<WashPackage>> GetWashPackage()
        {
            return await context.WashPackages.ToListAsync();
        }

        public async Task<WashPackage> GetWashPackageById(int id)
        {
            return await context.WashPackages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WashPackage> UpdateWashPackage(int id, WashPackage washPackage)
        {
            var existingdata = await context.WashPackages.FirstOrDefaultAsync(x => x.Id == id);
            if (washPackage == null)
            {
                return null;
            }

            existingdata.Name = washPackage.Name;
            existingdata.Description = washPackage.Description;
            existingdata.Price = washPackage.Price;

            await context.SaveChangesAsync();
            return existingdata;
        }

        public async Task<WashPackage> CreateWashPackage(WashPackage washPackage)
        {
            await context.WashPackages.AddAsync(washPackage);
            await context.SaveChangesAsync();
            return washPackage;
        }
    }
}
