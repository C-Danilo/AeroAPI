using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AeroportoAPI.Model;
using AeroportoAPI.DTO;

namespace AeroportoAPI.Controllers
{
    //Classe de crud do local da viagem
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ReservaContext _context;

        public LocalController(ReservaContext context)
        {
            _context = context;
        }

        // GET: api/Local
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetLocais()
        {
            return  _context.Locais.Select(item => new
            {
                item.nome                
            }).ToList();
        }

        // GET: api/Local/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(int id)
        {
            var local = await _context.Locais.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            return local;
        }

        // PUT: api/Local/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocal(int id, LocalDTO localDto)
        {

            var local = await _context.Locais.FindAsync(id);
            local.nome = localDto.nome;

            if (id != local.Id)
            {
                return BadRequest();
            }

            _context.Entry(local).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalExists(id))
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

        // POST: api/Local
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(LocalDTO localDto)
        {
            var localModel = new Local();
           
            localModel.nome = localDto.nome;

            _context.Locais.Add(localModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocal", new { id = localModel.Id }, localModel);
        }

        // DELETE: api/Local/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Local>> DeleteLocal(int id)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Locais.Remove(local);
            await _context.SaveChangesAsync();

            return local;
        }

        private bool LocalExists(int id)
        {
            return _context.Locais.Any(e => e.Id == id);
        }
    }
}
