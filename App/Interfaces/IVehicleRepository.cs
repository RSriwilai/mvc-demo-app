using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;

namespace App.Interfaces
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetVehicleAsync();
        Task<Vehicle> GetVehicleByRegNoAsync(string regNo);
        Task<Vehicle> GetVehicleByIdAsync(int id);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);


    }
}