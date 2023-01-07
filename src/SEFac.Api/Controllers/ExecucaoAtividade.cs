using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Application.Services.Interfaces;

namespace SEFac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExecucaoAtividade : ApiController
    {

        private readonly IAtividadeService _service;

        public ExecucaoAtividade(IAtividadeService atividadeService)
        {
            _service = atividadeService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDto>> Get(int id)
        {
            return Ok(await _service.GetAtividade(id));
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<int>> CadastrarAtividade([FromBody] CadastrarAtividadeDto cadastrarAtividadeDto)
        {
            var result = await _service.CadastrarAtividade(cadastrarAtividadeDto);

            return CreatedAtAction(nameof(Get), new { Id = result }, result);
        }

        [HttpPost("atualizar")]
        [Produces("application/json")]
        public async Task<ActionResult<AtividadeDto>> AtualizarAtividade([FromBody] AtualizarAtividadeDto atualizarAtividadeDto)
        {
            var serviceResponse = await _service.AtualizarAtividade(atualizarAtividadeDto);

            return Ok(serviceResponse);
        }
    }
}
