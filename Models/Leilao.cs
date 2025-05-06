using System.ComponentModel.DataAnnotations;

namespace LanceCerto.WebApp.Models
{
    public class Leilao
    {
        [Key]
        public int LeilaoId { get; set; }

        public int ImovelId { get; set; }

        public Imovel Imovel { get; set; }

        public int? VencedorId { get; set; }
        public Usuario? Vencedor { get; set; }

        public DateTime InicioEm { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Data de início do Leilão")]
        public DateTime FimEm { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Data do fim do Leilão")]

        public string Status { get; set; } // PENDENTE, ATIVO, ENCERRADO
        public decimal MaiorLanceAtual { get; set; }
    }
}