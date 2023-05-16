namespace SEFAC.Application.Dtos.Response
{
    public class ExecucaoAtividadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal CargaHoraria { get; set; }
        public decimal Duracao { get; set; }
        public string NomeAluno { get; set; }
        public int IdAluno { get; set; }
    }
}
