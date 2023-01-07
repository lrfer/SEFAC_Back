using SEFAC.Domain.Entities;

namespace SEFAC.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        bool ExisteEmail(string email);
        Task<Usuario> BuscarPorEmail(string email);
    }
}
