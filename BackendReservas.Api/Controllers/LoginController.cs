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
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("cliente")]
        public ActionResult<Cliente> loginCliente([FromServices] ReservasContext context, [FromBody] Login login)
        {
            var cliente = context.Clientes
                .AsNoTracking()
                .Include(c => c.Endereco)
                .Where(c => c.Email == login.email && c.Senha == login.senha)
                .FirstOrDefault();

            if(cliente != null) {
                return cliente;
            } else {
                return NotFound("Email ou senha inválidos");
            }
        }

        [HttpPost]
        [Route("estabelecimento")]
        public ActionResult<Estabelecimento> loginEstabelecimento([FromServices] ReservasContext context, [FromBody] Login login)
        {
            var estabelecimento = context.Estabelecimentos
                .AsNoTracking()
                .Include(e => e.Endereco)
                .Where(e => e.Email == login.email && e.Senha == login.senha)
                .FirstOrDefault();

            if(estabelecimento != null) {
                return estabelecimento;
            } else {
                return NotFound("Email ou senha inválidos");
            }
        }
    }
}