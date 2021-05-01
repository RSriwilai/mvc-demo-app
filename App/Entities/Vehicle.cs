namespace App.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public int ModelYear { get; set; }
        public int Mileage { get; set; }

    }
}