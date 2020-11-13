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
    //classe de crud da reserva
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaContext _context;

        public ReservaController(ReservaContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public ActionResult GetReservas()
        {
            /* return _context.Reservas.Select(item => new
             {
                 item.Id,
                 item.VooId,
                 //item.Voo,
                 item.Documento,
                 item.Poltrona

             }).ToList();*/
            return Ok(Convert(_context.Reservas.ToList()));
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
           
            return Ok(Convert(_context.Reservas.Where(Reserva => Reserva.Id == id).ToList()));          

            //return reserva;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaDTO reservaDto)
        {
            var reservaModel = await _context.Reservas.FindAsync(id);
            reservaModel.Documento = reservaDto.Documento;
            reservaModel.VooId = reservaDto.VooId;
            reservaModel.Poltrona = reservaDto.Poltrona;

            if (id != reservaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDTO reservaDto)
        {
            var reserva = new Reserva();
            reserva.Documento = reservaDto.Documento;
            reserva.VooId = reservaDto.VooId;
            reserva.Poltrona = reservaDto.Poltrona;

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }

        private IEnumerable<dynamic> Convert(List<Reserva> lista)
        {


            return lista.Select(item => new
            {
                 
                item.Id,
                item.VooId,
                item.Poltrona,
                item.Documento        
               
            });
        }


    }
}
