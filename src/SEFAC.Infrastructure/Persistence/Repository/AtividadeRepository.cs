using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class AtividadeRepository : BaseRepository<Domain.Entities.Atividade> , IAtividadeRepository
    {
        public AtividadeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
