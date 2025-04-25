namespace LanceCerto.WebApp.Models
{
    public class Leilao
    {
        public int LeilaoId { get; set; }

        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        public int? VencedorId { get; set; }
        public Usuario? Vencedor { get; set; }

        public DateTime InicioEm { get; set; }
        public DateTime FimEm { get; set; }

        public string Status { get; set; } // PENDENTE, ATIVO, ENCERRADO
        public decimal MaiorLanceAtual { get; set; }
    }
}