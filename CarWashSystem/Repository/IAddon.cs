using CarWashSystem.Models;

namespace CarWashSystem.Repository
{
    public interface IAddon
    {
        Task<List<AddOn>> GetAddOn();
        Task<AddOn> GetAddOnById(int id);
        Task<AddOn> CreateAddOn(AddOn addon);
        Task<AddOn> UpdateAddOn(int id, AddOn addon);
        Task<AddOn> DeleteAddOn(int id);
    }
}
