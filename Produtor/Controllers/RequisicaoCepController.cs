using System.Net;
using Microsoft.AspNetCore.Mvc;
using MassTransit;
using AutoMapper;
using CoreRequisicaoCEP;
using APIRequisicaoCEP.Dtos;

namespace APIRequisicaoCEP.Controllers
{
    [ApiController]
    [Route("/requisicaocep")]
    public class RequisicaoCepController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public RequisicaoCepController(IBus bus, IMapper mapper, IConfiguration configuration)
        {
            _bus = bus;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// Solicita a criação de um novo CEP.
        /// </summary>
        /// <param name="dtoCreate">Os dados para criar uma nova Requisição de CEP.</param>
        /// <returns>Retorna a Requisição de CEP se for bem-sucedido, caso contrário, retorna BadRequest.</returns>
        /// <remarks>
        /// Exemplo de solicitação:
        ///
        ///     POST /api/requisicaocep
        ///     {
        ///        "logradouro": "Rua exemplo",
        ///        "numero": "111",
        ///        "municipioId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <response code="202">Retorna a Requisição de CEP realizada com sucesso.</response>
        /// <response code="400">Retorna BadRequest se a solicitação for inválida.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequisicaoCepDtoCreate dtoCreate)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                RequisicaoCEP requisicaoCEP = _mapper.Map<RequisicaoCEP>(dtoCreate);
                requisicaoCEP.Id = Guid.NewGuid();

                //var nomeFila = _configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;
                var nomeFila = _configuration["kv-filarequisicaocep"] ?? string.Empty;

                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
                await endpoint.Send(requisicaoCEP);

                return Accepted(requisicaoCEP);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
