using CarWashSystem.Models;

namespace CarWashSystem.Repository
{
    public interface IWashPackage
    {
        Task<List<WashPackage>> GetWashPackage();
        Task<WashPackage> GetWashPackageById(int id);
        Task<WashPackage> CreateWashPackage(WashPackage washPackage);
        Task<WashPackage> UpdateWashPackage(int id, WashPackage washPackage);
        Task<WashPackage> DeleteWashPackage(int id);
    }
}
