using AutoRentalAPI.Models;

namespace AutoRentalAPI.Interfaces
{
    public interface IServicesContractRepository
    {
        Task<IEnumerable<ServicesContract>> GetAllServicesContractsAsync();
        Task<ServicesContract> GetServicesContractByIdAsync(int id);
        Task CreateServicesContractAsync(ServicesContract servicesContract);
        Task UpdateServicesContractAsync(ServicesContract servicesContract);
        Task DeleteServicesContractAsync(int id);
    }
}
