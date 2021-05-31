using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendReservas.Service;
using BackendReservas.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackendReservas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        [HttpGet]
        [Route("cliente")]
        public async Task<ActionResult<List<Avaliacao>>> GetAvaliacoescliente([FromServices] ReservasContext context, [FromQuery] int clienteId)
        {
            var avaliacoes = await context.Avaliacoes
                .AsNoTracking()
                .Where(x => x.ClienteId == clienteId)
                .ToListAsync();
            return avaliacoes;
        }
        
        [HttpGet]
        [Route("estabelecimento")]
        public async Task<ActionResult<List<Avaliacao>>> GetAvaliacoesEstabelecimento([FromServices] ReservasContext context, [FromQuery] int estabelecimentoID)
        {
            var avaliacoes = await context.Avaliacoes
                .AsNoTracking()
                .Where(x => x.EstablelecimentoId == estabelecimentoID)
                .ToListAsync();
            return avaliacoes;
        }      

        [HttpPost]
        [Route("cliente")]
        public async Task<ActionResult<Avaliacao>> PostAvalicacocliente([FromServices] ReservasContext context, [FromBody] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                context.Avaliacoes.Add(avaliacao);
                await context.SaveChangesAsync();
                return avaliacao;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}