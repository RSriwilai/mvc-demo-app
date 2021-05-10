using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository {get;}
        IManufacturerRepository ManufacturerRepository {get;}

        Task<bool> Complete();
        bool HasChanges();
    }
}