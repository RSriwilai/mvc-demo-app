using App.Data;
using App.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.ViewModels;
using Microsoft.EntityFrameworkCore;
using App.Interfaces;

namespace App.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Action metod...
        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            ViewBag.message ="Här är lite etra bra erbjudande för denna veckan!";
            var result = await _unitOfWork.VehicleRepository.GetVehicleAsync();
            return View("Index", result);
        }

        //STEG 1. ------------------> VIEW/VEHICLE Create.cshtml
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var list = await _unitOfWork.ManufacturerRepository.GetManufacturersAsync();

            return View("Create");
        }

        //STEG 3.
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVehicleViewModel data)
        {
            //kollar om alla ifyllda data uppfyller kravet - om inte return Create
            if (!ModelState.IsValid) return View("Create", data);

            //var result = data.RegistrationNumber;
            //return Content($"Sparat! - {result}");

            //STEG 5. SPARA TILL DATABAS
            //Manuellt mappa viewmodel till entitet
            var vehicle = new Vehicle
            {
                RegistrationNumber = data.RegistrationNumber,
                Make = data.Make,
                Model = data.Model,
                ModelYear = (int)data.ModelYear,
                Mileage = (int)data.Mileage,
                GearType = data.GearType,
                FuelType = data.FuelType,
            };


            //Placerar nu min entitet till EF ChangeTracking.
            _unitOfWork.VehicleRepository.Add(vehicle);
            // Nu sparas det till databasen..
            if (await _unitOfWork.Complete()) return RedirectToAction("Index");

            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditVehicleViewModel data)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetVehicleByIdAsync(data.Id);

            vehicle.Mileage = data.Mileage;
            vehicle.ModelYear = data.ModelYear;

            _unitOfWork.VehicleRepository.Update(vehicle);

            if (await _unitOfWork.Complete()) return RedirectToAction("Index");

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetVehicleByIdAsync(id);

            var model = new EditVehicleViewModel
            {
                Id = vehicle.Id,
                ModelYear = vehicle.ModelYear,
                Mileage = vehicle.Mileage
            };
            return View("Edit", model);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var vehicle = await _unitOfWork.VehicleRepository.GetVehicleByIdAsync(id);
            _unitOfWork.VehicleRepository.Delete(vehicle);

            if (await _unitOfWork.Complete()) return RedirectToAction("Index");
            return View("Error");
        }
    }
}


