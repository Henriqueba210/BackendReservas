using System.Threading.Tasks;
using BackendReservas.Service;
using BackendReservas.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendReservas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Estabelecimento>> PostEstabelecimento([FromServices] ReservasContext context, [FromBody] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                context.Estabelecimentos.Add(estabelecimento);
                await context.SaveChangesAsync();
                return estabelecimento;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Estabelecimento>> PutEstabelecimento([FromServices] ReservasContext context, [FromBody] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                context.Estabelecimentos.Update(estabelecimento);
                await context.SaveChangesAsync();
                return estabelecimento;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}