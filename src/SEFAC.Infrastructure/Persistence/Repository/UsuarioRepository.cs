using Microsoft.EntityFrameworkCore;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;
using System.Linq;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool ExisteEmail(string email) => _repository.Where(x => x.Email.Equals(email)).Any();


        public async Task<Usuario> BuscarPorEmail(string email) => await _repository.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }
}
