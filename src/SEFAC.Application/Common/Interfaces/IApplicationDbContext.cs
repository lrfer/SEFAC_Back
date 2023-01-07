using Microsoft.EntityFrameworkCore;
using SEFAC.Domain.Entities;

namespace SEFAC.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Aluno> Alunos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<ExecucoesAtividades> Atividades { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
