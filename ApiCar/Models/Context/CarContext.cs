using Microsoft.EntityFrameworkCore;

namespace ApiCar.Models
{
    public class CarContext : DbContext
    {
        public CarContext() { }
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        public DbSet<Car> Carro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=host.docker.internal; Database=CarroApp;User Id=leo;Password=123;");
        }
    }
}
