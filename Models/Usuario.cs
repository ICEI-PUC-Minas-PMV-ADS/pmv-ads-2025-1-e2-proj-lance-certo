namespace LanceCerto.WebApp.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estado { get; set; } // ATIVO, INATIVO, BLOQUEADO
        public bool EhVendedor { get; set; }
        public bool EhCorretor { get; set; }
        public string? Creci { get; set; }

        public ICollection<Imovel>? Imoveis { get; set; }
        public ICollection<Lance>? Lances { get; set; }
    }
}