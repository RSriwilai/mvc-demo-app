using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class EditVehicleViewModel
    { 
        public int Id { get; set; }
        
        [Display(Name = "Antal mil (km)")]
        public int Mileage { get; set; }

        [Display(Name = "Årsmodell")]
        public int ModelYear { get; set; }
    }
}