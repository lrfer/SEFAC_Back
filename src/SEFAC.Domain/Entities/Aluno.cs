namespace SEFAC.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        #region"Properties"
        public string NumeroMatricula { get; set; }
        public string Nome { get; set; }
        public string CodigoCurso { get; set; }

        #endregion

        #region "Virtual Properties"
        public virtual List<ExecucoesAtividades> ExecucaoAtividades { get; set; }

        #endregion
    }
}
