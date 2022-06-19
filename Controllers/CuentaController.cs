using API_Pichincha.Models;
using API_Pichincha.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Pichincha.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly DataContext _context;

        public CuentaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> ObtenerCuentas()
        {
            try
            {
                var cuenta = await _context.Cuenta.ToListAsync();
                return Ok(cuenta);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> ObtenerCuentasxId(int id)
        {
            try
            {
                var cuenta = await _context.Cuenta.FindAsync(id);
                if(cuenta == null)
                {
                    throw new Exception("No existe esa cuenta");
                }
                return Ok(cuenta);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Cuenta>>> AgregarCuenta(Cuenta cuenta)
        {
            try
            {
                _context.Cuenta.Add(cuenta);
                await _context.SaveChangesAsync();
                return Ok(await _context.Cuenta.ToListAsync());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Cuenta>>> ActualizarCuenta(Cuenta request)
        {
            try
            {
                var cuenta = await _context.Cuenta.FindAsync(request.Id_Cuenta);
                if (cuenta == null)
                {
                    throw new Exception("No Existe Cuenta para actualizar");
                }
                cuenta.Nro_Cuenta = request.Nro_Cuenta;
                cuenta.Tipo_Cuenta = request.Tipo_Cuenta.ToString();
                cuenta.Saldo_Inicial = request.Saldo_Inicial;
                cuenta.Saldo_Disponible = request.Saldo_Disponible;
                cuenta.Estado = request.Estado;
                cuenta.Id_Cliente = request.Id_Cliente;

                _context.Update(cuenta);
                await _context.SaveChangesAsync();
                return Ok(await _context.Cuenta.ToListAsync());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cuenta>>> EliminarCuenta(int id)
        {
            try
            {
                var cuenta = _context.Cuenta.Find(id);
                if(cuenta == null)
                {
                    throw new Exception("No existe cuenta para eliminar");
                }
                _context.Cuenta.Remove(cuenta);
                await _context.SaveChangesAsync();
                return Ok(await _context.Cuenta.ToListAsync());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
