using ProjetoLivraria.Domain.Model;
using ProjetoLivraria.Service.Api.Models;

namespace ProjetoLivraria.Service.Api.Adapters
{
    public class LivroAdapter
    {
        public static Livro ToDomainModel(LivroViewModel livroViewModel)
        {
            var livro = new Livro(livroViewModel.ISBN,
                                  livroViewModel.Autor,
                                  livroViewModel.Nome,
                                  livroViewModel.Preco,
                                  livroViewModel.DataPublicacao);

            return livro;
        }

        public static LivroViewModel ToViewModel(Livro livro)
        {
            var livroViewModel = new LivroViewModel()
            {
                ISBN = livro.ISBN,
                Autor = livro.Autor,
                Nome = livro.Nome,
                Preco = livro.Preco,
                DataPublicacao = livro.DataPublicacao
            };

            return livroViewModel;
        }
    }
}