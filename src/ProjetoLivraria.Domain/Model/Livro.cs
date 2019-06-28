using System;

namespace ProjetoLivraria.Domain.Model
{
    public class Livro
    {

        public Livro(string isbn,
                     string autor,
                     string nome,
                     decimal preco,
                     DateTime dataPublicacao)
        {
            ISBN = isbn;
            Autor = autor;
            Nome = nome;
            Preco = preco;
            DataPublicacao = dataPublicacao;
        }

        public string ISBN { get; private set; }
        public string Autor { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataPublicacao { get; private set; }
    }
}
