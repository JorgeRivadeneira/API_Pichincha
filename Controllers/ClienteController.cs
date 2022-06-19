using API_Pichincha.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Pichincha.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;
        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ObtenerClientes()
        {
            try
            {
                var clientes = await _context.Cliente.ToListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AgregarCliente(Cliente cliente)
        {
            Persona persona = new Persona()
            {
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
            };

            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();
            var idPersona = (int)persona.Id_Persona;

            //encrypt password
            byte[] encData_byte = new byte[cliente.Password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(cliente.Password);
            string encodedData = Convert.ToBase64String(encData_byte);

            Cliente client = new Cliente()
            {
                Id_Cliente = 0,
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Password = encodedData,
                Estado = cliente.Estado, 
                Id_Persona = idPersona
            };

            _context.Cliente.Add(client);

            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> ActualizarCliente(Cliente request)
        {
            try
            {
                var cliente = await _context.Cliente.FindAsync(request.Id_Cliente);
                if (cliente == null)
                {
                    throw new Exception("Cliente no Encontrado");
                }

                Persona persona = new Persona()
                {
                    Nombre = request.Nombre,
                    Genero = request.Genero,
                    Edad = request.Edad,
                    Identificacion = request.Identificacion,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                };

                _context.Persona.Update(persona);
                await _context.SaveChangesAsync();
                var idPersona = (int)persona.Id_Persona;

                //encrypt password
                byte[] encData_byte = new byte[request.Password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(request.Password);
                string encodedData = Convert.ToBase64String(encData_byte);

                Cliente client = new Cliente()
                {
                    Id_Cliente = 0,
                    Nombre = request.Nombre,
                    Genero = request.Genero,
                    Edad = request.Edad,
                    Identificacion = request.Identificacion,
                    Password = encodedData,
                    Estado = request.Estado,
                    Id_Persona = idPersona
                };

                _context.Cliente.Update(client);
                await _context.SaveChangesAsync();


                return Ok(await _context.Cliente.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> EliminarCliente(int id)
        {
            try
            {
                var client = await _context.Cliente.FindAsync(id);
                if(client == null)
                {
                    return NotFound("Cliente no Encontrado");
                }
                _context.Cliente.Remove(client);
                await _context.SaveChangesAsync();
                return Ok(await _context.Cliente.FindAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
