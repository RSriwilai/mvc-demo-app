using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _context;
        public VehicleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
           
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<Vehicle> GetVehicleByRegNoAsync(string regNo)
        {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(c => c.RegistrationNumber.ToUpper() == regNo.ToUpper());


            return vehicle;
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }
    }
}