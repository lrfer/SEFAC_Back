using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
