using AutoMapper;
using SEFac.Api.Controllers;
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

            CreateMap<CadastrarExecucaoAtividadeDto, ExecucoesAtividades>().ReverseMap();

            CreateMap<ExecucoesAtividades, ExecucaoAtividadeDto>()
                .ForMember(dest=> dest.NomeAluno, opt=>opt.MapFrom(source => source.Aluno.Nome))
                .ForMember(dest=> dest.NomeAtividade, opt=> opt.MapFrom(source => source.Atividade.CodigoSiex))
                .ReverseMap();

            CreateMap<Atividade, AtividadeDto>().ForMember(dest => dest.Documento_base64, opt => opt.MapFrom(source => source.Base64PDF)).ReverseMap();

            CreateMap<Atividade, CadastrarAtividadeDto>().ForMember(dest => dest.Documento_base64, opt => opt.MapFrom(opt => opt.Base64PDF)).ReverseMap();
        }
    }
}
