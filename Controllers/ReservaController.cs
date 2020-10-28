using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroportoAPI.Model;
using AeroportoAPI.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroportoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private List<Reserva> Reservas = new List<Reserva>();
        private int Id = 1;

        [HttpPost]
        public IActionResult EfetuarReserva(EfetuarReservaRequest request)
        {
            var reserva = new Reserva();
            reserva.Id = Id;
            Id = Id++;
            reserva.Documento = request.Documento;
            reserva.Id = request.VooId;
            reserva.Poltrona = request.Poltrona;

            Reservas.Add(reserva);

            return Ok(reserva.Id);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            return null;
        }

        [HttpGet("BuscaPorVoo/{VooId}")]
        public IActionResult BuscaPorVoo(int vooid)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirId(int id)
        {
            return null;
        }

        [HttpPut]
        public IActionResult Editar(EditarReservaRequest request)
        {
            return null;
        }

        [HttpGet("BuscarPoltronaVazia/{idPoltrona}")]
        public IActionResult BuscarPoltronaVazia(int idPoltrona)
        {
            return null;
        }

    }
}
