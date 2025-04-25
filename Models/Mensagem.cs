namespace LanceCerto.WebApp.Models
{
    public class Mensagem
    {
        public int MensagemId { get; set; }

        public int RemetenteId { get; set; }
        public Usuario Remetente { get; set; }

        public int DestinatarioId { get; set; }
        public Usuario Destinatario { get; set; }

        public int? ImovelRelacionadoId { get; set; }
        public Imovel? ImovelRelacionado { get; set; }

        public string Conteudo { get; set; }
        public DateTime EnviadaEm { get; set; }
    }
}