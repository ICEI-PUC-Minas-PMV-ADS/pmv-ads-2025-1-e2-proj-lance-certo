namespace LanceCerto.WebApp.Models
{
    public class Lance
    {
        public int LanceId { get; set; }

        public int LeilaoId { get; set; }
        public Leilao Leilao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public decimal ValorLance { get; set; }
        public DateTime MomentoLance { get; set; }
    }
}