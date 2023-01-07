namespace SEFAC.Domain.Entities
{
    public class ExecucoesAtividades : BaseEntity
    {
        #region "Properties"
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime CargaHoraria { get; set; }
        public DateTime Duracao { get; set; }
        public int IdAluno { get; set; }
        #endregion
        #region "Virtual Properties"
        public virtual Aluno Aluno { get; set; }
        #endregion
    }
}
