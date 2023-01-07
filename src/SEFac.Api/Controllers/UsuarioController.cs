using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Services.Interfaces;

namespace SEFac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _service = usuarioService;
        }


        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<ActionResult<bool>> Authenticate([FromBody] UsuarioDto login)
        {
            try
            {
                
                return Ok(await _service.Autenticar(login));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        [HttpPost("cadastar")]
        public async Task<ActionResult<string>> CadastrarUsuario([FromBody] UsuarioDto login)
        {
            try
            {
                return Ok(await _service.CadastrarUsuario(login));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
