using AutoRentalAPI.Models;

namespace AutoRentalAPI.Interfaces
{
    public interface ICarTypeRepository
    {
        Task<IEnumerable<CarType>> GetAllCarTypesAsync();
        Task<CarType> GetCarTypeByIdAsync(int id);
        Task CreateCarTypeAsync(CarType carType);
        Task UpdateCarTypeAsync(CarType carType);
        Task DeleteCarTypeAsync(int id);
    }
}
