using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(6)")]

        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public int ModelYear { get; set; }
        public int Mileage { get; set; }
        public string Comment { get; set; }

    }
}