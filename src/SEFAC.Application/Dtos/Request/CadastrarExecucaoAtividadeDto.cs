namespace SEFAC.Application.Dtos.Request
{
    public class CadastrarExecucaoAtividadeDto
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal CargaHoraria { get; set; }
        public decimal Duracao { get; set; }
        public int IdAluno { get; set; }
        public int IdAtividade { get; set; }
    }
}
