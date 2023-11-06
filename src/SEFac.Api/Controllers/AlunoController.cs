using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Application.Services.Interfaces;
using SEFAC.Domain.Const;

namespace SEFac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ApiController
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService alunoService)
        {
            _service = alunoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDto>> Get(int id)
        {
            return Ok(await _service.GetAluno(id));
        }


        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AlunoCriadoDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> CadastrarAluno([FromBody] CadastrarAlunoDto cadastrarAlunoDto)
        {
            var serviceResponse = await _service.CadastarAluno(cadastrarAlunoDto);

            return CreatedAtAction(nameof(Get), new { Id = serviceResponse }, serviceResponse);
        }

        [HttpPost("atualizar")]
        [Produces("application/json")]
        public async Task<ActionResult<AlunoDto>> AtualizarAluno([FromBody] AtualizarAlunoDto atualizarAlunoDto)
        {
            var serviceResponse = await _service.AtualizarAluno(atualizarAlunoDto);

            return Ok(serviceResponse);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAlunos()
        {
            var serviceResponse = await _service.GetAll();
            return new ObjectResult(serviceResponse);
        }

        [HttpGet("relatorio/{idAluno}")]
        public async Task<IActionResult> GerarRelatorio(int idAluno)
        {
            var relatorio = await _service.GerarRelatorio(idAluno);
            return Ok(relatorio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
