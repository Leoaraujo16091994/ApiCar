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
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CarroApp;Data Source=JOSAFA-PC\\SQLEXPRESS");
        }
    }
}
