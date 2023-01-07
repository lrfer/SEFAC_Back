using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Services.Interfaces;
using SEFAC.Domain.Const;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BC = BCrypt.Net.BCrypt;

namespace SEFAC.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        #region "Ctor"
        public UsuarioService(IUsuarioRepository repository, IMapper mapper,
                        IConfiguration configuration)
        {
            _usuarioRepository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }
        #endregion
        #region "Public Methods"

        public async Task<bool> CadastrarUsuario(UsuarioDto usuarioDto)
        {
            var user = _mapper.Map<Usuario>(usuarioDto);

            if (_usuarioRepository.ExisteEmail(user.Email))
                throw new Exception("Email já cadastrado");

            var senha = BC.HashPassword(user.Senha);

            Usuario usuario = new Usuario(user.Email, senha,user.Nome);

            await _usuarioRepository.Insert(usuario);

            return true;
        }

        public async Task<string> Autenticar(UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.BuscarPorEmail(usuarioDto.Email);

            if (usuario is null)
                throw new Exception("Usuário ou senha incorretos");

            if (!BC.Verify(usuarioDto.Senha, usuario.Senha))
                throw new Exception("Usuário ou senha incorretos");

            return GerarJwt(usuario);

        }
        #endregion

        #region "Private Methods"
        private string GerarJwt(Usuario usuario)
        {
            var claims = GetTokenClaims(usuario.Email, usuario.Nome, true, true);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));

            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credenciais);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

        private static IEnumerable<Claim> GetTokenClaims(string user, string nome, bool isAdmin = false, bool isProfessor = false)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, nome),
                new Claim(JwtRegisteredClaimNames.UniqueName, user),
                new Claim("role", Role.ALUNO)
            };

            List<string> Roles = new List<string>
            {
                Role.ALUNO
            };

            if (isAdmin)
            {
                claims.Add(new Claim("role", Role.ADMIN));
                Roles.Add(Role.ADMIN);
            }
            if (isProfessor)
            {
                claims.Add(new Claim("role", Role.PROFESSOR));
                Roles.Add(Role.PROFESSOR);
            }

            return claims;
        }
        #endregion
    }
}
