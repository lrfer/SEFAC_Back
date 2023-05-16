using Microsoft.EntityFrameworkCore;
using SEFAC.Domain.Interfaces.Repositories;
using System.Linq.Expressions;
using System.Linq;
using SEFAC.Domain.Entities;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class ExecucaoAtividadeRepository : BaseRepository<Domain.Entities.ExecucoesAtividades>, IExecucaoAtividadeRepository
    {
        public ExecucaoAtividadeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ExecucoesAtividades>> GetAllWithAluno(Expression<Func<ExecucoesAtividades, bool>>? filtro = null)
        {
            if (filtro is null)
                return await _repository.Include(x=>x.Aluno).ToListAsync();

            return await _repository.Include(x=>x.Aluno).Where(filtro).ToListAsync();
        }
    }
}
