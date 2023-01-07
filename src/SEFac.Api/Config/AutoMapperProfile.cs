using AutoMapper;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Domain.Entities;

namespace SEFac.Api.Config
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CadastrarAlunoDto, Aluno>().ReverseMap();

            CreateMap<AlunoDto, Aluno>().ReverseMap();

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
