using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;

namespace SEFAC.Application.Services.Interfaces
{
    public interface IAtividadeService
    {
        Task<int> CadastrarAtividade(CadastrarAtividadeDto cadastrarAtividadeDto);
        Task<AtividadeDto> GetAtividade(int id);

        Task<AtividadeDto> AtualizarAtividade(AtualizarAtividadeDto atualizarAtivdadeDto);
    }
}
