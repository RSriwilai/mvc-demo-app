using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;

namespace App.Interfaces
{
    public interface IManufacturerRepository
    {
        void Add(Manufacturer manufacturer);
        Task<IEnumerable<Manufacturer>> GetManufacturersAsync();
    }
}