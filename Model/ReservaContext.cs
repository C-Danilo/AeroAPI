using Microsoft.EntityFrameworkCore;
namespace AeroportoAPI.Model
{
       //classe principai do Entity Framework
    public class ReservaContext : DbContext
    {
        public DbSet<Local> Locais { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Voo> Voos { get; set; }

        public ReservaContext(DbContextOptions<ReservaContext> options) : base(options) { }
        

    }
}
