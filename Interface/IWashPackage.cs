using CarWashSystem.Models;

namespace CarWashSystem.Interface
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
