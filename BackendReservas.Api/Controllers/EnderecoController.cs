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
    public class EnderecoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Endereco>>> GetEnderecos ([FromServices] ReservasContext context)
        {
            var enderecos = await context.Enderecos
                .AsNoTracking()
                .ToListAsync();
            return enderecos;
        }

        [HttpGet]
        [Route("cidade/{cidade}")]
        public async Task<ActionResult<List<Endereco>>> GetEnderecosCidade ([FromServices] ReservasContext context, [FromRoute] string cidade)
        {
            var enderecos = await context.Enderecos
                .Where(e => e.Cidade == cidade)
                .AsNoTracking()
                .ToListAsync();
            return enderecos;
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Endereco>> putEndereco ([FromServices] ReservasContext context, [FromBody] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                context.Enderecos.Update(endereco);
                await context.SaveChangesAsync();
                return endereco;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}