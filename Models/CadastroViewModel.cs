using System;
using System.ComponentModel.DataAnnotations;

namespace LanceCerto.WebApp.Models
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage ="O nome completo é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage ="E-mail inválido.")]
        public string Email { get; set; }


        [Required(ErrorMessage ="A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage ="A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
