using System;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repo;

        //TODO! Gör om detta till repository när det fungerar! CHECK
        public VehiclesController(IVehicleRepository repo)
        {
            _repo = repo;
        }

        //Fyra saker att hålla koll på GET, PUT, POST, DELETE..

        [HttpGet()]
        public async Task<IActionResult> GetVehicles()
        {
            var result = await _repo.GetVehicleAsync();
            return Ok(result);
        }

        [HttpGet("{regNo}")]
        public async Task<IActionResult> GetVehicle(string regNo)
        {
            try
            {
                // var vehicle = await _context.Vehicles.SingleOrDefaultAsync(c => c.RegistrationNumber.ToUpper() == regNo.ToUpper());
                var vehicle = await _repo.GetVehicleByRegNoAsync(regNo);

                if(vehicle == null) return NotFound();
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            try
            {
                // _context.Vehicles.Add(vehicle);
                // var result = await _context.SaveChangesAsync();
                await _repo.AddAsync(vehicle);

                if(await _repo.SaveAllChangesAsync()) return StatusCode(201);

                return StatusCode(500, "Det gick inget vidare!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicleModel)
        {
            //Steg 1. Hämta befintlig bil med hjälp av inskickat id
            var vehicle = await _repo.GetVehicleByIdAsync(id);
            //Steg 2. Uppdatera de egenskaper ifrån steg 1 med värden ifrån modellen
            vehicle.FuelType = vehicleModel.FuelType;
            vehicle.GearType = vehicleModel.GearType;
            vehicle.Make = vehicleModel.Make;
            vehicle.Mileage = vehicleModel.Mileage;
            vehicle.Model = vehicleModel.Model;
            vehicle.ModelYear = vehicleModel.ModelYear;
            //Steg 3. Spara!
            // _context.Update(vehicle);
            _repo.Update(vehicle);
            // var result = await _context.SaveChangesAsync();
            var result = await _repo.SaveAllChangesAsync();
            return NoContent();
        }

        [HttpDelete("{regNo}")]
        public async Task<IActionResult> DeleteVehicle(string regNo)
        {
            try
            {
                // var vehicle = await _context.Vehicles.SingleOrDefaultAsync(c => c.RegistrationNumber.ToUpper() == regNo.ToUpper());
                var vehicle = await _repo.GetVehicleByRegNoAsync(regNo);
                if (vehicle == null) return NotFound();

                // _context.Vehicles.Remove(vehicle);
                _repo.Delete(vehicle);

                // var result = _context.SaveChangesAsync();
                var result = _repo.SaveAllChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);             
            }

        }

    }
}