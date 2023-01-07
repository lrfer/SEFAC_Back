using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEFAC.Application.Common.Interfaces;
using SEFAC.Domain.Entities;

namespace SEFAC.Infrastructure.Persistence
{

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        protected readonly IConfiguration Configuration;
        #region Ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
         : base(options)
        {
            Configuration = configuration;
        }
        #endregion
        #region DbSet
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<ExecucoesAtividades> Atividades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion
        #region Methods
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }
        #endregion

    }

}
