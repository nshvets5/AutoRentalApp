using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRentalAPI.Repositories
{
    public class ServicesContractRepository : IServicesContractRepository
    {
        private readonly AutoRentalContext _context;

        public ServicesContractRepository(AutoRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicesContract>> GetAllServicesContractsAsync()
        {
            return await _context.ServicesContracts
                .Include(sc => sc.Contract)
                .Include(sc => sc.Service)
                .ToListAsync();
        }

        public async Task<ServicesContract> GetServicesContractByIdAsync(int id)
        {
            return await _context.ServicesContracts
                .Include(sc => sc.Contract)
                .Include(sc => sc.Service)
                .FirstOrDefaultAsync(sc => sc.ServiceContractId == id);
        }

        public async Task CreateServicesContractAsync(ServicesContract servicesContract)
        {
            _context.ServicesContracts.Add(servicesContract);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServicesContractAsync(ServicesContract servicesContract)
        {
            _context.Entry(servicesContract).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServicesContractAsync(int id)
        {
            var servicesContract = await _context.ServicesContracts.FindAsync(id);
            if (servicesContract != null)
            {
                _context.ServicesContracts.Remove(servicesContract);
                await _context.SaveChangesAsync();
            }
        }
    }
}
