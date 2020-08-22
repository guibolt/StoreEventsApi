using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreEvents.Application.Commands.CreateCupom;
using StoreEvents.Application.Queries.GetCupom;
using StoreEvents.Application.Queries.GetCupons;

namespace StoreEvents.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CuponsController(IMediator mediator) =>  _mediator = mediator;


        [Route("cadastra")]
        [HttpPost]
        public async Task<IActionResult> CadastraCupom([FromBody] CreateCupomInputModel createCupomInput)
        {
            var comando = new CreateCupomCommand(createCupomInput);

            var retorno = await _mediator.Send(comando);

            return retorno.Sucesso ? Created("", retorno) : (ActionResult)BadRequest(retorno);

        }

        [Route("busca")]
        [HttpGet]
        public async Task<IActionResult> BuscaCupons()
        {
            var query = new GetCuponsQuery();

            var retorno = await _mediator.Send(query);

            return retorno.Sucesso  ? Ok(retorno) : (ActionResult)BadRequest(retorno);

        }

        [HttpGet("buscaporid/{cupomId}")]
        public async Task<IActionResult> BuscaCupom(string cupomId)
        {
            var query = new GetCuponQuery(cupomId);

            var retorno = await _mediator.Send(query);

            return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
        }
    }
}
