using System.Threading.Tasks;
using BackendReservas.Service;
using BackendReservas.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendReservas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> PostCliente([FromServices] ReservasContext context, [FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(cliente);
                await context.SaveChangesAsync();
                return cliente;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Cliente>> PutCliente([FromServices] ReservasContext context, [FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Update(cliente);
                await context.SaveChangesAsync();
                return cliente;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}