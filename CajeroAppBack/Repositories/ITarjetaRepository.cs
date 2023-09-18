using CajeroAppBack.Entidades;

namespace CajeroAppBack.Repositories
{
    public interface ITarjetaRepository : IRepository<Tarjeta>
    {
        Tarjeta GetTarjetaPorNumero(string numeroTarjeta);

        Tarjeta GetTarjetaConMovimientos(string numeroTarjeta);
    }
}
