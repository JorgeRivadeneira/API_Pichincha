using API_Pichincha.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Pichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            try
            {
                Persona persona = new Persona();
                Cliente cliente = new Cliente();

                return Ok(await _context.Cliente.ToListAsync());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        //{
        //    _context.SuperHeroes.Add(hero);
        //    await _context.SaveChangesAsync();
        //    return Ok(await _context.SuperHeroes.ToListAsync());
        //}
    }
}
