using ProjetoLivraria.Domain.Model;
using System.Collections.Generic;

namespace ProjetoLivraria.Domain.Interfaces
{
    public interface ILivroRepository
    {
        void Adicionar(Livro livro);
        void Atualizar(Livro livro);
        IEnumerable<Livro> ObterTodos();
        Livro ObterLivroPorISBN(string isbn);
        void Remover(string isbn);
        IEnumerable<Livro> Pesquisar(string tipoPesquisa, string valorPesquisa);
    }
}
