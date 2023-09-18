using CajeroAppBack.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CajeroAppBack.Repositories
{
    public class RepositoryTarjeta : Repository<Tarjeta>, ITarjetaRepository
    {
        public RepositoryTarjeta(ApplicationDbContext context) : base(context) { }

        public Tarjeta GetTarjetaPorNumero(string numeroTarjeta)
        {
            return _dbSet.FirstOrDefault(tarjetaDb => tarjetaDb.NumeroTarjeta == numeroTarjeta);
        }
        public Tarjeta GetTarjetaConMovimientos(string numeroTarjeta)
        {
            return _dbSet.Include(tarjetaDb => tarjetaDb.Operaciones).FirstOrDefault(tarjetaDb => tarjetaDb.NumeroTarjeta == numeroTarjeta);
        }
    }
}
