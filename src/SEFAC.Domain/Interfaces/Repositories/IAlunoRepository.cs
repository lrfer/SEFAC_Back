using SEFAC.Domain.Entities;

namespace SEFAC.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {

        Task<Aluno> GetAlunoWithInclude(int id);
    }
}
