using SEFAC.Application.Dtos.Request;

namespace SEFAC.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> CadastrarUsuario(UsuarioDto usuarioDto);

        Task<string> Autenticar(UsuarioDto usuarioDto);
    }
}
