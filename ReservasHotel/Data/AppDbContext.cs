using Microsoft.EntityFrameworkCore;
//using ReservasHotel.Models;



    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Huesped> huespedes { get; set; }
        public DbSet<Reserva> reservas { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSnakeCaseNamingConvention();

            base.OnModelCreating(modelBuilder);

        }*/
    }
