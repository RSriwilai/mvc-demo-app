using App.Data;
using App.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
  public class VehiclesController : Controller
  {
    private readonly DataContext _context;
      public VehiclesController(DataContext context)
      {
          _context = context;
      }
 
        //Action metod...
        [HttpGet()]
    public async Task<IActionResult> Index()
    {
      var result = await _context.Vehicles.ToListAsync();
      return View("Index", result);
    }

    //STEG 1. ------------------> VIEW/VEHICLE Create.cshtml
    [HttpGet]
    public IActionResult Create()
    {
      return View("Create");
    }

    //STEG 3.
    [HttpPost]
    public async Task<IActionResult> Create(RegisterVehicleViewModel data) 
    {
      //var result = data.RegistrationNumber;
      //return Content($"Sparat! - {result}");

      //STEG 5. SPARA TILL DATABAS
      //Manuellt mappa viewmodel till entitet
      var vehicle = new Vehicle 
      {
        RegistrationNumber = data.RegistrationNumber,
        Make = data.Make,
        Model = data.Model,
        ModelYear = data.ModelYear,
        Mileage = data.Mileage,
        GearType = data.GearType,
        FuelType = data.FuelType,
      };


      //Placerar nu min entitet till EF ChangeTracking.
      _context.Vehicles.Add(vehicle);
      // Nu sparas det till databasen..
      var result = await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVehicleViewModel data)
    {
      var vehicle = await _context.Vehicles.FindAsync(data.Id);
      
      vehicle.Mileage = data.Mileage;
      vehicle.ModelYear = data.ModelYear;

      _context.Vehicles.Update(vehicle);
      var result = await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var vehicle = await _context.Vehicles.FindAsync(id);

      var model = new EditVehicleViewModel
      {
        Id = vehicle.Id,
        ModelYear = vehicle.ModelYear,
        Mileage = vehicle.Mileage
      }; 
      return View("Edit", model);
    }
  }
}


 