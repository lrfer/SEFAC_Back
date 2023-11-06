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
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        public AtividadeService(IAtividadeRepository atividadeRepository, IMapper mapper)
        {
            _atividadeRepository = atividadeRepository;
            _mapper = mapper;
        }

        public async Task<Atividade> CadastrarAtividade(CadastrarAtividadeDto cadastrarAtividadeDto)
        {
            var atividade = _mapper.Map<Atividade>(cadastrarAtividadeDto); 
            var insert = await _atividadeRepository.Insert(atividade);

            return insert;

        }

        public async Task<AtividadeDto> GetAtividade(int id)
        {
            return _mapper.Map<AtividadeDto>(await _atividadeRepository.GetById(id));
        }

        public async Task<IEnumerable<AtividadeDto>> GetAtividades()
        {
            return _mapper.Map<IEnumerable<AtividadeDto>>(await _atividadeRepository.GetAll());
        }
    }
}
