using AutoMapper;
using SEFAC.Application.Dtos.Request;
using SEFAC.Application.Dtos.Response;
using SEFAC.Application.Services.Interfaces;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Source;

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

        public async Task<byte[]> GerarRelatorio(int idAluno)
        {
            var aluno = await _alunoRepository.GetAlunoWithInclude(idAluno);

            ByteArrayOutputStream stream = new ByteArrayOutputStream();

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(new PdfDocument(new PdfWriter(ms)));

                PopularDocumento(aluno, document);

                document.Close();

                byte[] result = ms.ToArray();

                return result;

            }

        }

        private static void PopularDocumento(Aluno aluno, Document document)
        {
            document.Add(new Paragraph(aluno.Nome)
                .SetFontSize(16)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetMarginBottom(20)
                );

            var execAtividadeOrder = aluno.ExecucaoAtividades.OrderBy(x => x.Atividade.Id);


            foreach (var exec in execAtividadeOrder)
            {
                var idAtividade = exec.Atividade.Id;
                int idAntigo = -99;
                if(idAtividade != idAntigo)
                { 
                    document.Add(new Paragraph("Atividade :  " + exec.Atividade.CodigoSiex)
                            .SetFontSize(14)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetMarginBottom(20));
                    idAntigo = idAtividade;                         
                }



                document.Add(new Paragraph(exec.Nome)
                   .SetFontSize(14)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetMarginBottom(20));

                document.Add(new Paragraph("Duração : " + exec.Duracao.ToString())
                   .SetFontSize(14)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetMarginBottom(20));

                document.Add(new Paragraph("Data Inicio : " + exec.DataInicio.ToString())
                      .SetFontSize(14)
                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                      .SetMarginBottom(20));

                document.Add(new Paragraph("Data Fim : " + exec.DataFim.ToString())
                      .SetFontSize(14)
                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                      .SetMarginBottom(20));

                document.Add(new Paragraph("CargaHoraria : " + exec.CargaHoraria.ToString())
                      .SetFontSize(14)
                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                      .SetMarginBottom(20));


                document.Add(new Paragraph("________________________________________")
                      .SetFontSize(14)
                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                      .SetMarginBottom(20));
            }


            document.Add(new Paragraph("Carga Horaria total : " + aluno.ExecucaoAtividades.Sum(x=>x.CargaHoraria))
                  .SetFontSize(14)
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                  .SetMarginBottom(20));

        }

        public async Task Delete(int idAluno)
        {
            await _alunoRepository.Delete(idAluno);
        }

        #endregion
    }

}
