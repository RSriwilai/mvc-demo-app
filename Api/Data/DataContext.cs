using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}