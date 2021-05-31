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
    public class FidelidadeController : ControllerBase
    {
        [HttpGet]
        [Route("cliente")]
        public async Task<ActionResult<List<Fidelidade>>> GetFidelidadescliente([FromServices] ReservasContext context, [FromQuery] int clienteId)
        {
            var fidelidades = await context.Fidelidades
                .Where(x => x.ClienteId == clienteId)
                .ToListAsync();
            return fidelidades;
        }
        
        [HttpGet]
        [Route("estabelecimento")]
        public async Task<ActionResult<List<Fidelidade>>> GetFidelidadesEstabelecimento([FromServices] ReservasContext context, [FromQuery] int estabelecimentoID)
        {
            var fidelidades = await context.Fidelidades
                .Where(x => x.EstablelecimentoId == estabelecimentoID)
                .ToListAsync();
            return fidelidades;
        }      

        [HttpPut]
        [Route("cliente")]
        public async Task<ActionResult<Fidelidade>> PostFidelidadecliente([FromServices] ReservasContext context, [FromBody] Fidelidade fidelidade)
        {
            if (ModelState.IsValid)
            {
                context.Fidelidades.Update(fidelidade);
                await context.SaveChangesAsync();
                return fidelidade;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}