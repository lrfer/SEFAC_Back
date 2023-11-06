namespace SEFAC.Domain.Entities
{
    public class Atividade : BaseEntity
    {
        public string CodigoSiex { get; set; }
        public string Descricao { get; set; }
        public string? Base64PDF { get; set; }

        #region "Virtual Properties"
        public virtual IList<ExecucoesAtividades> Execucoes { get; set; }
        #endregion
    }
}
