using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Service.Api.Models
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
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Obrigatório preencher este campo.")]
        [DisplayName("Data da Publicação")]
        public DateTime DataPublicacao { get; set; }
    }
}