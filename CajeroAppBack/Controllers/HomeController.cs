using CajeroAppBack.Entidades;
using CajeroAppBack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CajeroAppBack.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController: ControllerBase
    {
        private readonly ITarjetaRepository _tarjetaRepository;
        private readonly IRepository<Operacion> _operacionRepository;

        public HomeController(ITarjetaRepository tarjetaRepository, IRepository<Operacion> operacionRepository)
        {
            _tarjetaRepository = tarjetaRepository;
            _operacionRepository = operacionRepository;
        }

        [HttpGet("verificarTarjetaIngresada")]
        public async Task<ActionResult<Tarjeta>> VerificarTarjeta (string numeroTarjeta)
        {
            var tarjeta = _tarjetaRepository.GetTarjetaPorNumero(numeroTarjeta);
            if (tarjeta == null || tarjeta.Bloqueada)
            {
                return BadRequest("La tarjeta no existe o se encuentra bloqueada");
            }
            _tarjetaRepository.Update(tarjeta);
            return Ok(tarjeta);
        }

        [HttpGet("verificarPin")]

        public async Task<ActionResult<Tarjeta>> VerificarPin(string numeroTarjeta, int pin)
        {
            var tarjeta = _tarjetaRepository.GetTarjetaPorNumero(numeroTarjeta);

            if (tarjeta.Pin != pin)
            {
                tarjeta.IngresoPinErroneo++;
                if (tarjeta.IngresoPinErroneo == 4)
                {
                    tarjeta.Bloqueada = true;
                    tarjeta.IngresoPinErroneo = 0;
                    _tarjetaRepository.Update(tarjeta);
                    return BadRequest("Tarjeta bloqueada");
                }
                _tarjetaRepository.Update(tarjeta);
                return BadRequest("PIN incorrecto");
            }
            tarjeta.IngresoPinErroneo = 0;
            _tarjetaRepository.Update(tarjeta);
            return Ok(tarjeta);
        }

        [HttpGet("consultarBalance")]
        public async Task<ActionResult<Tarjeta>> ConsultarBalance(string numeroTarjeta)
        {
            var tarjeta = _tarjetaRepository.GetTarjetaConMovimientos(numeroTarjeta);

            var operacion = new Operacion
            {
                IdTarjeta = tarjeta.Id,
                FechaHora = DateTime.Now,
                CantidadRetirada = 0
            };

            _operacionRepository.Add(operacion);


            if (tarjeta.Operaciones == null)
            {
                tarjeta.Operaciones = new List<Operacion>();
            }

            tarjeta.Operaciones.Add(operacion);

            _tarjetaRepository.Update(tarjeta);

            return Ok(tarjeta);
        }

        [HttpGet("retirarDinero")]
        public async Task<ActionResult<Operacion>> RetirarDinero (string numeroTarjeta, double cantidad)
        {
            var tarjeta = _tarjetaRepository.GetTarjetaConMovimientos(numeroTarjeta);

            if (tarjeta.Balance < cantidad)
            {
                return BadRequest("Saldo insuficiente");
            }

            var operacion = new Operacion
            {
                IdTarjeta = tarjeta.Id,
                FechaHora = DateTime.Now,
                CantidadRetirada = cantidad
            };

            _operacionRepository.Add(operacion);


            if (tarjeta.Operaciones == null)
            {
                tarjeta.Operaciones = new List<Operacion>();
            }

            tarjeta.Operaciones.Add(operacion);
            tarjeta.Balance = tarjeta.Balance - cantidad;
            _tarjetaRepository.Update(tarjeta);

            return Ok(operacion);
        }


    } 
}
