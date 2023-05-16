namespace SEFAC.Application.Dtos.Request
{
    public class CadastrarAtividadeDto
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal CargaHoraria { get; set; }
        public decimal Duracao { get; set; }
        public int IdAluno { get; set; }
    }
}
