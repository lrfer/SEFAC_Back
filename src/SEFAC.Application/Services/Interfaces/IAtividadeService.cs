using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Domain.Entities;

namespace SEFAC.Application.Services.Interfaces
{
    public interface IAtividadeService
    {
        Task<AtividadeDto> GetAtividade(int id);

        Task<Atividade> CadastrarAtividade(CadastrarAtividadeDto cadastrarAtividadeDto);

        Task<IEnumerable<AtividadeDto>> GetAtividades();
    }
}
