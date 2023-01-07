using SEFAC.Domain.Interfaces.Repositories;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class ExecucaoAtividadeRepository : BaseRepository<Domain.Entities.ExecucoesAtividades>, IExecucaoAtividadeRepository
    {
        public ExecucaoAtividadeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
