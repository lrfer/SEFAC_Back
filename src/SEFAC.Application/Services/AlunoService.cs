using AutoMapper;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Application.Services.Interfaces;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;

namespace SEFAC.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        #region Ctor
        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        public async Task<int> CadastarAluno(CadastrarAlunoDto cadastrarAlunoDto)
        {
            var aluno = _mapper.Map<Aluno>(cadastrarAlunoDto);

            var result = await _alunoRepository.Insert(aluno);

            return result.Id;
        }

        public async Task<AlunoDto> GetAluno(int id)
        {
            var entity = await _alunoRepository.GetById(id);
            return _mapper.Map<AlunoDto>(entity);
        }
        public async Task<AlunoDto> AtualizarAluno(AtualizarAlunoDto atualizarAlunoDto)
        {
            var aluno = _mapper.Map<Aluno>(atualizarAlunoDto);
            var result = await _alunoRepository.Update(aluno);

            return _mapper.Map<AlunoDto>(result);
        }

        public async Task<List<AlunoDto>> GetAll()
        {
            var result = await _alunoRepository.GetAll();

            return _mapper.Map<List<AlunoDto>>(result);
        }
        #endregion
    }

}
