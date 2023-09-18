namespace CajeroAppBack.Entidades
{
    public class Operacion
    {
        public int Id { get; set; }
        public int IdTarjeta { get; set; }
        public DateTime FechaHora { get; set; }
        public double CantidadRetirada { get; set; }
        public Tarjeta Tarjeta { get; set; }
    }
}
