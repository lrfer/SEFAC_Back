using Microsoft.AspNetCore.Mvc;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Services.Interfaces;

namespace SEFac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ApiController
    {
       private readonly IAtividadeService _atividadeService;

        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAtividade(CadastrarAtividadeDto cadastrarAtividadeDto)
        {
            var result = await _atividadeService.CadastrarAtividade(cadastrarAtividadeDto);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtividade(int id)
        {
            var result = await _atividadeService.GetAtividade(id);

            return Ok(result);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAtividades()
        {
            var result = await _atividadeService.GetAtividades();

            return Ok(result);  
        }
        
    }
}
