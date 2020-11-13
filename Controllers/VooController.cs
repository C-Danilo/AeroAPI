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
        public IActionResult GetVoos()
        {
            return Ok(Convert(_context.Voos.ToList()));
            /*return _context.Voos.Select(item => new
            {
                item.Id,
                item.dataIda,
                item.dataVolta,
                item.LocalOrigemId,
                item.LocalDestinoId,
                item.NumeroParadas,
                item.Preco
            }).ToList();*/
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
            return Ok(Convert(_context.Voos.Where(Voo => Voo.Id == id).ToList()));


           

            //return voo;
        }

        // PUT: api/Voo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, VooDTO vooDto)
        {
            var vooModel = await _context.Voos.FindAsync(id);
            vooModel.LocalOrigemId = vooDto.LocalOrigemId;
            vooModel.LocalDestinoId = vooDto.LocalDestinoId;
            vooModel.NumeroParadas = vooDto.NumeroParadas;
            //vooModel.TempoIda = vooDto.TempoIda;
            //vooModel.TempoVolta = vooDto.TempoVolta;
            vooModel.Preco = vooDto.Preco;
            vooModel.dataIda = vooDto.dataIda;
            vooModel.dataVolta = vooDto.dataVolta;

            if (id != vooModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vooModel).State = EntityState.Modified;

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
        public async Task<ActionResult<Voo>> PostVoo(VooDTO vooDto)
        {
            var vooModel = new Voo();
            vooModel.LocalOrigemId = vooDto.LocalOrigemId;
            vooModel.LocalDestinoId = vooDto.LocalDestinoId;
            vooModel.NumeroParadas = vooDto.NumeroParadas;
            //vooModel.TempoIda = vooDto.TempoIda;
            //vooModel.TempoVolta = vooDto.TempoVolta;
            vooModel.Preco = vooDto.Preco;
            vooModel.dataIda = vooDto.dataIda;
            vooModel.dataVolta = vooDto.dataVolta;
            _context.Voos.Add(vooModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = vooModel.Id }, vooModel);
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
            var listaDeRetorno = _context.Voos.Where(item => item.LocalDestinoId == filtro.DestinoId 
                                                          && item.LocalOrigemId == filtro.OrigemId 
                                                          && item.dataIda == filtro.dataInicial 
                                                          && item.dataVolta == filtro.dataFinal);

            return Ok(Convert(listaDeRetorno.ToList()));
            //return Ok(_context.Voos.ToList());
        }

        private IEnumerable<dynamic> Convert(List<Voo> lista) 
         {


             return lista.Select(item => new
             {
                 item.Id,
                 item.dataIda,
                 item.dataVolta,
                 item.LocalOrigemId,
                 item.LocalDestinoId,
                 item.NumeroParadas,
                 item.Preco
             });
         }

    }
}
