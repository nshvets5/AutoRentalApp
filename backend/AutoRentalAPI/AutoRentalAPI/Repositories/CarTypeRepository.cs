using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRentalAPI.Repositories
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly AutoRentalContext _context;

        public CarTypeRepository(AutoRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarType>> GetAllCarTypesAsync()
        {
            return await _context.CarTypes.ToListAsync();
        }

        public async Task<CarType> GetCarTypeByIdAsync(int id)
        {
            return await _context.CarTypes.FindAsync(id);
        }

        public async Task CreateCarTypeAsync(CarType carType)
        {
            _context.CarTypes.Add(carType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarTypeAsync(CarType carType)
        {
            _context.Entry(carType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarTypeAsync(int id)
        {
            var carType = await _context.CarTypes.FindAsync(id);
            if (carType != null)
            {
                _context.CarTypes.Remove(carType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
