using System.ComponentModel.DataAnnotations;
namespace App.ViewModels
{
    public class RegisterVehicleViewModel
    {
        [Display(Name = "RegNummer")]
        public string RegistrationNumber {get; set;}

        [Display(Name = "Tillverkare")]
        public string Make { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Växellåda")]
        public string GearType { get; set; }

        [Display(Name = "Bränsletyp")]
        public string FuelType { get; set; }

        [Display(Name = "Antal mil (km)")]
        public int Mileage { get; set; }

        [Display(Name = "Årsmodell")]
        public int ModelYear { get; set; }

    }
}