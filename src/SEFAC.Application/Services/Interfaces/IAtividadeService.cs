using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;

namespace SEFAC.Application.Services.Interfaces
{
    public interface IAtividadeService
    {
        Task<int> CadastrarAtividade(CadastrarAtividadeDto cadastrarAtividadeDto);
        Task<ExecucaoAtividadeDto> GetAtividade(int id);

        Task<ExecucaoAtividadeDto> AtualizarAtividade(AtualizarAtividadeDto atualizarAtivdadeDto);

        Task<List<ExecucaoAtividadeDto>> GetAll();
    }
}
