using System.ComponentModel.DataAnnotations;

namespace LanceCerto.WebApp.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título pode ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de imóvel é obrigatório.")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "Informe a sigla do estado com 2 caracteres.")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço mínimo é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "Informe um valor válido.")]
        public decimal PrecoMinimo { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public string Status { get; set; } = string.Empty;

        public string? ImagemUrl { get; set; }

        // Relacionamento com o usuário (proprietário ou anunciante)
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Navegação reversa (muitos favoritos por imóvel)
        public ICollection<ImovelFavorito> ImoveisFavoritos { get; set; } = new List<ImovelFavorito>();
    }
}