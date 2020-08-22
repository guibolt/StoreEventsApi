using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreEvents.Application.Commands.CreatePromocao;

namespace StoreEvents.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PromocoesController : ControllerBase
    {

        private readonly IMediator _mediator;
        public PromocoesController(IMediator mediator) => _mediator = mediator;

        [Route("cadastra")]
        [HttpPost]
        public async Task<IActionResult> CadastraPromocao([FromBody] CreatePromocaoInputModel inputModel)
        {
            var comando = new CreatePromocaoCommand(inputModel);

            var retorno = await _mediator.Send(comando);

            return retorno.Sucesso ? Created("", retorno) : (ActionResult)BadRequest(retorno);
        }

        [Route("busca")]
        [HttpGet]
        public async Task<IActionResult> BuscaPromocoes() => Ok(new Dictionary<string, string> { { "Bebo", "Suco" } });


        [HttpGet("buscaporid/{promocaoId}")]
        public async Task<IActionResult> BuscaPromocao(string promocaoId) => null;
    }
}
