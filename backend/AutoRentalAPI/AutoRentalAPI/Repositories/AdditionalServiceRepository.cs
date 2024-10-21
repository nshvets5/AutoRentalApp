using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRentalAPI.Repositories
{
    public class AdditionalServiceRepository : IAdditionalServiceRepository
    {
        private readonly AutoRentalContext _context;

        public AdditionalServiceRepository(AutoRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdditionalService>> GetAllAdditionalServicesAsync()
        {
            return await _context.AdditionalServices.ToListAsync();
        }

        public async Task<AdditionalService> GetAdditionalServiceByIdAsync(int id)
        {
            return await _context.AdditionalServices.FirstOrDefaultAsync(s => s.ServiceId == id);
        }

        public async Task CreateAdditionalServiceAsync(AdditionalService additionalService)
        {
            _context.AdditionalServices.Add(additionalService);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdditionalServiceAsync(AdditionalService additionalService)
        {
            _context.Entry(additionalService).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdditionalServiceAsync(int id)
        {
            var additionalService = await _context.AdditionalServices.FindAsync(id);
            if (additionalService != null)
            {
                _context.AdditionalServices.Remove(additionalService);
                await _context.SaveChangesAsync();
            }
        }
    }
}
