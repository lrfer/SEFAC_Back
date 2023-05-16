using SEFAC.Domain.Entities;
using System.Linq.Expressions;

namespace SEFAC.Domain.Interfaces.Repositories
{
    public interface IExecucaoAtividadeRepository : IBaseRepository<ExecucoesAtividades>
    {
        Task<List<ExecucoesAtividades>> GetAllWithAluno(Expression<Func<ExecucoesAtividades, bool>>? filtro = null);
    }
}
