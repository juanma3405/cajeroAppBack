using System.ComponentModel.DataAnnotations;
namespace CajeroAppBack.Entidades
{
    public class Tarjeta
    {
        public int Id { get; set; }
        
        [StringLength(16)]
        public string NumeroTarjeta { get; set; }
        public int Pin { get; set; }
        public bool Bloqueada { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IngresoPinErroneo { get; set; }
        public double Balance { get; set; }
        public List<Operacion> Operaciones { get; set; }
    }
}
