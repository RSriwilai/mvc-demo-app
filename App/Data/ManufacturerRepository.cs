using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;
using App.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DataContext _context;
        public ManufacturerRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Manufacturer manufacturer)
        {
            _context.Add(manufacturer);
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturersAsync()
        {
            return await _context.Manufactures.ToListAsync();
        }

    }
}