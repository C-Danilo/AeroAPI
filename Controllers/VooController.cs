using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AeroportoAPI.Model;
using AeroportoAPI.DTO;
using Microsoft.AspNetCore.Razor.Language;

namespace AeroportoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly ReservaContext _context;

        public VooController(ReservaContext context)
        {
            _context = context;
        }

        // GET: api/Voo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetVoos()
        {
            //return Ok(Convert(_context.Voos.ToList()));
            return _context.Voos.Select(item => new
            {
                item.Id,
                item.dataIda,
                item.dataVolta,
                item.LocalOrigemID,
                item.LocalDestinoID,
                item.NumeroParadas,
                item.Preco
            }).ToList();
        }

        // GET: api/Voo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, VooDTO vooDto)
        {
            var voo = await _context.Voos.FindAsync(id);            
            voo.LocalOrigemID = vooDto.LocalOrigemID;
            voo.LocalDestinoID = vooDto.LocalDestinoID;
            voo.NumeroParadas = vooDto.NumeroParadas;
            //voo.TempoIda = vooDto.TempoIda;
           // voo.TempoVolta = vooDto.TempoVolta;
            voo.Preco = vooDto.Preco;
            voo.dataIda = vooDto.dataIda;
            voo.dataVolta = vooDto.dataVolta;

            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voo>> PostVoo(Voo voo)
        {
            _context.Voos.Add(voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voo>> DeleteVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();

            return voo;
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.Id == id);
        }

        [HttpGet("FiltroVoos")]
        public ActionResult GetByFilter( [FromQuery]FiltroVooDTO filtro )
        {
            var listaDeRetorno = _context.Voos.Where(item => item.LocalDestinoID.Id == filtro.DestinoId && item.LocalOrigemID.Id == filtro.OrigemId && item.dataIda == filtro.dataInicial && item.dataVolta == filtro.dataFinal).ToList();
            //return Ok(Convert(listaDeRetorno.ToList()));
            return Ok(listaDeRetorno);
        }

        /* public IEnumerable<dynamic> Convert(List<Voo> listaVoos) 
         {


             return listaVoos.Select(item => new
             {
                 item.Id,
                 item.dataIda,
                 item.dataVolta,
                 item.LocalOrigemID,
                 item.LocalDestinoID,
                 item.NumeroParadas,
                 item.Preco
             });
         }*/

    }
}
