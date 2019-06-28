using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Mvc.Models
{
    public class LivroViewModel
    {
        [Required(ErrorMessage = "Obrigatório preencher este campo.")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Obrigatório preencher este campo.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Obrigatório preencher este campo.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório preencher este campo.")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Obrigatório preencher este campo.")]
        public DateTime DataPublicacao { get; set; }
    }
}
