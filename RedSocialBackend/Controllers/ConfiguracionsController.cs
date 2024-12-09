using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedSocialBackend.DataContext;
using RedSocialServices.Models;

namespace RedSocialBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionsController : ControllerBase
    {
        private readonly RedSocialContext _context;

        public ConfiguracionsController(RedSocialContext context)
        {
            _context = context;
        }

        // GET: api/Configuracions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuracion>>> GetConfiguraciones()
        {
            return await _context.Configuraciones.ToListAsync();
        }

        // GET: api/Configuracions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configuracion>> GetConfiguracion(int id)
        {
            var configuracion = await _context.Configuraciones.FindAsync(id);

            if (configuracion == null)
            {
                return NotFound();
            }

            return configuracion;
        }

        // PUT: api/Configuracions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracion(int id, Configuracion configuracion)
        {
            if (id != configuracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(configuracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Configuracions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Configuracion>> PostConfiguracion(Configuracion configuracion)
        {
            _context.Configuraciones.Add(configuracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfiguracion", new { id = configuracion.Id }, configuracion);
        }

        // DELETE: api/Configuracions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracion(int id)
        {
            var configuracion = await _context.Configuraciones.FindAsync(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            _context.Configuraciones.Remove(configuracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfiguracionExists(int id)
        {
            return _context.Configuraciones.Any(e => e.Id == id);
        }
    }
}
