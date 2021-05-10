using System.ComponentModel.DataAnnotations;
namespace App.ViewModels
{
    public class RegisterVehicleViewModel
    {
        [Display(Name = "RegNummer")]
        [StringLength(maximumLength: 6, MinimumLength = 6, ErrorMessage = "*Registeringsnummr måste vara exakt 6 tecken")]
        [Required(ErrorMessage = "*Registeringsnummer måste anges!")]
        public string RegistrationNumber {get; set;}

        [Display(Name = "Tillverkare")]
        [Required(ErrorMessage = "*Du måste ange tillverkare")]
        public string Make { get; set; }

        [Display(Name = "Modell")]
        [Required(ErrorMessage = "*Du måste ange bilens modell")]
        public string Model { get; set; }

        [Display(Name = "Växellåda")]
        [Required(ErrorMessage = "*Du måste ange vilken typ av växellåda")]
        public string GearType { get; set; }

        [Display(Name = "Bränsletyp")]
        [Required(ErrorMessage = "*Du måste ange bränsletyp")]
        public string FuelType { get; set; }
        
        [Display(Name = "Antal mil (km)")]
        [Required(ErrorMessage = "*Du måste ange antal mil i km")]
        public int? Mileage { get; set; }

        [Display(Name = "Årsmodell")]
        [Required(ErrorMessage = "*Du måste ange bilens årsmodell")]
        public int? ModelYear { get; set; }

        [Display(Name = "Kommentar")]
        //[DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Display(Name = "Importerad")]
        public bool IsImported { get; set; }

    }
}