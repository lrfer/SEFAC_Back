using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;

namespace SEFAC.Application.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<int> CadastarAluno(CadastrarAlunoDto cadastrarAlunoDto);
        Task<AlunoDto> GetAluno(int id);

        Task<AlunoDto> AtualizarAluno(AtualizarAlunoDto atualizarAlunoDto);
        Task<List<AlunoDto>> GetAll();
    }
}
