using Microsoft.EntityFrameworkCore;
using CajeroAppBack.Entidades;

namespace CajeroAppBack
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder); 
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var tarjeta1 = new Tarjeta()
            {
                Id = 1,
                NumeroTarjeta = "1001100110011001",
                Pin = 1212,
                Bloqueada = false,
                FechaVencimiento = new DateTime(2023, 12, 18),
                Balance = 0,
                Operaciones = null
            };

            var tarjeta2 = new Tarjeta()
            {
                Id = 2,
                NumeroTarjeta = "1002100210021002",
                Pin = 1515,
                Bloqueada = false,
                FechaVencimiento = new DateTime(2023, 12, 18),
                Balance = 0,
                Operaciones = null
            };

            var tarjeta3 = new Tarjeta()
            {
                Id = 3,
                NumeroTarjeta = "1003100310031003",
                Pin = 1616,
                Bloqueada = false,
                FechaVencimiento = new DateTime(2023, 12, 18),
                IngresoPinErroneo = 0,
                Balance = 15000,
                Operaciones = null
            };

            var tarjeta4 = new Tarjeta()
            {
                Id = 4,
                NumeroTarjeta = "1004100410041004",
                Pin = 1717,
                Bloqueada = false,
                FechaVencimiento = new DateTime(2023, 12, 18),
                IngresoPinErroneo = 0,
                Balance = 5000,
                Operaciones = null
            };

            modelBuilder.Entity<Tarjeta>()
                .HasData(new List<Tarjeta> { tarjeta1, tarjeta2, tarjeta3, tarjeta4 });
        }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }    
    }
}
