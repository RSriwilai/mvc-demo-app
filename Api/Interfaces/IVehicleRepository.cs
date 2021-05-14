using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetVehicleAsync();
        Task<Vehicle> GetVehicleByRegNoAsync(string regNo);
        Task<Vehicle> GetVehicleByIdAsync(int id);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);
        Task<bool> SaveAllChangesAsync();
    }
}