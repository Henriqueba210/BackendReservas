using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendReservas.Service;
using BackendReservas.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackendReservas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        [HttpGet]
        [Route("cliente")]
        public async Task<ActionResult<List<Reserva>>> GetReservascliente([FromServices] ReservasContext context, [FromQuery] int clienteId)
        {
            var reservas = await context.Reservas
                .AsNoTracking()
                .Where(x => x.ClienteId == clienteId)
                .ToListAsync();
            return reservas;
        }
        
        [HttpGet]
        [Route("estabelecimento")]
        public async Task<ActionResult<List<Reserva>>> GetReservasEstabelecimento([FromServices] ReservasContext context, [FromQuery] int estabelecimentoID)
        {
            var reservas = await context.Reservas
                .AsNoTracking()
                .Where(x => x.EstablelecimentoId == estabelecimentoID)
                .ToListAsync();
            return reservas;
        }      

        [HttpPut]
        [Route("cliente")]
        public async Task<ActionResult<Reserva>> PostReservascliente([FromServices] ReservasContext context, [FromBody] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                context.Reservas.Update(reserva);
                await context.SaveChangesAsync();
                return reserva;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}