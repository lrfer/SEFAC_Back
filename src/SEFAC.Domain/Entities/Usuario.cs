namespace SEFAC.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        private const string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; set; }
        public Usuario(string email, string senha,string nome)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
        }
    }
}
