using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRentalAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AutoRentalContext _context;

        public CarRepository(AutoRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.Include(c => c.CarType).ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.Include(c => c.CarType).FirstOrDefaultAsync(c => c.CarId == id);
        }

        public async Task CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
