using Microsoft.EntityFrameworkCore;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Aluno> GetAlunoWithInclude(int id)
        {
            return  await _repository
                .Include(x => x.ExecucaoAtividades)
                .ThenInclude(x=>x.Atividade)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
