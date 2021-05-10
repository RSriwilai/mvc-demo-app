using Microsoft.EntityFrameworkCore;
using App.Entities;

namespace App.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Manufacturer> Manufactures { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}