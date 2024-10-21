using AutoRentalAPI.Models;

namespace AutoRentalAPI.Interfaces
{
    public interface IAdditionalServiceRepository
    {
        Task<IEnumerable<AdditionalService>> GetAllAdditionalServicesAsync();
        Task<AdditionalService> GetAdditionalServiceByIdAsync(int id);
        Task CreateAdditionalServiceAsync(AdditionalService additionalService);
        Task UpdateAdditionalServiceAsync(AdditionalService additionalService);
        Task DeleteAdditionalServiceAsync(int id);
    }
}
