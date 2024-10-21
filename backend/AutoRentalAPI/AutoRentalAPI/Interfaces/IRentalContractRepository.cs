using AutoRentalAPI.Models;

namespace AutoRentalAPI.Interfaces
{
    public interface IRentalContractRepository
    {
        Task<IEnumerable<RentalContract>> GetAllContractsAsync();
        Task<RentalContract> GetContractByIdAsync(int id);
        Task CreateContractAsync(RentalContract contract);
        Task UpdateContractAsync(RentalContract contract);
        Task DeleteContractAsync(int id);
    }
}
