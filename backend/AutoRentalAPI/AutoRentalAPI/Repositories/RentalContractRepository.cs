using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRentalAPI.Repositories
{
    public class RentalContractRepository : IRentalContractRepository
    {
        private readonly AutoRentalContext _context;

        public RentalContractRepository(AutoRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalContract>> GetAllContractsAsync()
        {
            return await _context.RentalContracts
                .Include(rc => rc.Client)
                .Include(rc => rc.Car)
                .ToListAsync();
        }

        public async Task<RentalContract> GetContractByIdAsync(int id)
        {
            return await _context.RentalContracts
                .Include(rc => rc.Client)
                .Include(rc => rc.Car)
                .FirstOrDefaultAsync(rc => rc.ContractId == id);
        }

        public async Task CreateContractAsync(RentalContract contract)
        {
            _context.RentalContracts.Add(contract);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContractAsync(RentalContract contract)
        {
            _context.Entry(contract).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContractAsync(int id)
        {
            var contract = await _context.RentalContracts.FindAsync(id);
            if (contract != null)
            {
                _context.RentalContracts.Remove(contract);
                await _context.SaveChangesAsync();
            }
        }
    }
}
