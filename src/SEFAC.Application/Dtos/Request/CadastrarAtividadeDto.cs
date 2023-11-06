namespace SEFAC.Application.Dtos.Request
{
    public class CadastrarAtividadeDto
    {
        public string CodigoSiex { get; set; }
        public string Descricao { get; set; }
        public string? Documento_base64 { get; set; }
    }
}
