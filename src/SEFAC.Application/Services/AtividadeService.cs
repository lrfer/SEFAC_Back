using AutoMapper;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Application.Services.Interfaces;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;

namespace SEFAC.Application.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IExecucaoAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        #region Ctor
        public AtividadeService(IExecucaoAtividadeRepository atividadeRepository, IMapper mapper)
        {
            _atividadeRepository = atividadeRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        public async Task<int> CadastrarAtividade(CadastrarAtividadeDto cadastrarAtividadeDto)
        {
            var atividade = _mapper.Map<ExecucoesAtividades>(cadastrarAtividadeDto);
            var result = await _atividadeRepository.Insert(atividade);

            return result.Id;
        }

        public async Task<ExecucaoAtividadeDto> GetAtividade(int id)
        {
            return _mapper.Map<ExecucaoAtividadeDto>(await _atividadeRepository.GetById(id));
        }
        public async Task<ExecucaoAtividadeDto> AtualizarAtividade(AtualizarAtividadeDto atualizarAtivdadeDto)
        {
            var atividade = _mapper.Map<ExecucoesAtividades>(atualizarAtivdadeDto);
            var result = await _atividadeRepository.Update(atividade);

            return _mapper.Map<ExecucaoAtividadeDto>(result);
        }

        public async Task<List<ExecucaoAtividadeDto>> GetAll()
        {
            var result = await _atividadeRepository.GetAllWithAluno();

            return _mapper.Map<List<ExecucaoAtividadeDto>>(result);
        }

        #endregion
    }
}
