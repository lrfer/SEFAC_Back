using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;

namespace SEFAC.Application.Services.Interfaces
{
    public interface IExecucaoAtividadeService
    {
        Task<int> CadastrarAtividade(CadastrarExecucaoAtividadeDto cadastrarAtividadeDto);
        Task<ExecucaoAtividadeDto> GetAtividade(int id);

        Task<ExecucaoAtividadeDto> AtualizarAtividade(AtualizarAtividadeDto atualizarAtivdadeDto);

        Task<List<ExecucaoAtividadeDto>> GetAll();
    }
}
