namespace LanceCerto.WebApp.Models
{
    public class ImovelFavorito
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }
    }
}