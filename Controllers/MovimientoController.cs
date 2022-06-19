using API_Pichincha.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API_Pichincha.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovimientoController : ControllerBase
    {
        private readonly DataContext _context;

        public MovimientoController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint para devolver un movimiento especifico
        /// </summary>
        /// <param name="id">Id único del movimiento</param>
        /// <returns>Movimiento</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoResults>> ObtenerMovimientosxId(int id)
        {
            try
            {
                var movimiento = await _context.Movimientos.FindAsync(id);

                if (movimiento == null)
                {
                    return NotFound("Movimiento no encontrado");
                }

                var mov = (from m in _context.Movimientos
                           join c in _context.Cuenta
                           on m.Id_Cuenta equals c.Id_Cuenta
                           select new
                           {
                               idCliente = c.Id_Cliente,
                               Fecha = m.Fecha,
                               Nro_Cuenta = c.Nro_Cuenta,
                               Tipo = (c.Tipo_Cuenta.ToString() == "A") ? "Ahorros" : "Corriente" ,
                               Saldo_Inicial = m.Saldo_Inicial,
                               Valor = m.Valor,
                               Saldo_Disponible = m.Saldo,
                               Estado = c.Estado,
                               Tipo_Transaccion = (m.Tipo_Movimiento == "D") ? "Débito" : "Crédito"
                           }).FirstOrDefault();
                var cliente = await _context.Cliente.FindAsync(mov.idCliente);

                MovimientoResults movResults = new MovimientoResults()
                {
                    Fecha = mov.Fecha,
                    Cliente = cliente.Nombre,
                    Nro_Cuenta = mov.Nro_Cuenta,
                    Tipo = mov.Tipo,
                    Saldo_Inicial = mov.Saldo_Inicial,
                    Monto = mov.Valor,
                    Saldo_Disponible = mov.Saldo_Disponible,
                    Estado = mov.Estado,
                    Tipo_Transaccion = mov.Tipo_Transaccion
                };

                return Ok(movResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MovimientoResults>>> ObtenerReporteMovimientos([FromQuery] QueryParam parametros)
        {
            try
            {
                var cliente = await _context.Cliente.FindAsync(parametros.idCliente);

                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                var mov = await (from m in _context.Movimientos
                           join c in _context.Cuenta
                           on m.Id_Cuenta equals c.Id_Cuenta
                           where c.Id_Cliente == parametros.idCliente 
                           && m.Fecha >= parametros.FechaInicial
                           && m.Fecha <= parametros.FechaFinal
                           select new
                           {
                               idCliente = c.Id_Cliente,
                               Fecha = m.Fecha,
                               Nro_Cuenta = c.Nro_Cuenta,
                               Tipo = (c.Tipo_Cuenta.ToString() == "A") ? "Ahorros" : "Corriente",
                               Saldo_Inicial = m.Saldo_Inicial,
                               Valor = m.Valor,
                               Saldo_Disponible = m.Saldo,
                               Estado = c.Estado,
                               Tipo_Transaccion = (m.Tipo_Movimiento == "D") ? "Débito" : "Crédito"
                           }).ToListAsync();
                List<MovimientoResults> movimientoResults = new List<MovimientoResults>();

                foreach(var movimiento in mov)
                {
                    MovimientoResults movResults = new MovimientoResults()
                    {
                        Fecha = movimiento.Fecha,
                        Cliente = cliente.Nombre,
                        Nro_Cuenta = movimiento.Nro_Cuenta,
                        Tipo = movimiento.Tipo,
                        Saldo_Inicial = movimiento.Saldo_Inicial,
                        Monto = movimiento.Valor,
                        Saldo_Disponible = movimiento.Saldo_Disponible,
                        Estado = movimiento.Estado,
                        Tipo_Transaccion = movimiento.Tipo_Transaccion
                    };
                    movimientoResults.Add(movResults);
                }

                return Ok(movimientoResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Movimientos>> ActualizarMovimiento(Movimientos request)
        {
            try
            {
                var movimiento = await _context.Movimientos.FindAsync(request.Id_Movimiento);
                if(movimiento == null)
                {
                    return NotFound("No existe el movimiento: " + request.Id_Movimiento.ToString());
                }
                movimiento.Tipo_Movimiento = request.Tipo_Movimiento;
                movimiento.Fecha = DateTime.Now;
                movimiento.Valor = request.Valor;
                movimiento.Id_Cuenta = request.Id_Cuenta;
                await _context.SaveChangesAsync();
                return Ok(await _context.Movimientos.FindAsync(request.Id_Movimiento));

            }catch(Exception ex)
            {
                if (string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
        }


        [HttpPost]
        public async Task<ActionResult<Movimientos>> AgregarMovimiento(Movimientos movimiento)
        {
            try
            {
                _context.Movimientos.Add(movimiento);
                //Está creado un trigger en la BDD para vlidar el saldo no disponible
                //y el cupo diario, 
                //dichas validaciones se activan al insertar/actualizar
                await _context.SaveChangesAsync();
                var idMovimiento = (int)movimiento.Id_Movimiento;
                return Ok(await _context.Movimientos.FindAsync(idMovimiento));
            }catch (Exception ex)
            {
                if (string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return BadRequest(ex.InnerException.Message);
                }
                
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> EliminarMovimiento(int id)
        {
            try
            {
                var movimiento = await _context.Movimientos.FindAsync(id);
                if (movimiento == null)
                {
                    return BadRequest("No Existe ese Movimiento");
                }
                _context.Movimientos.Remove(movimiento);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
        }

    }
}
