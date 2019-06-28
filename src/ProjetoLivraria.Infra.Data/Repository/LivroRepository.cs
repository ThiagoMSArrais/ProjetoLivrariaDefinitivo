using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjetoLivraria.Domain.Interfaces;
using ProjetoLivraria.Domain.Model;

namespace ProjetoLivraria.Infra.Data.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string ConnectionString = @"Data Source=LAPTOP-70823SQ1\SQLEXPRESS;Initial Catalog=ProjetoLivraria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Adicionar(Livro livro)
        {

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string SqlAdicionarLivro = "INSERT INTO LIVRO (ISBN, Autor, Nome, Preco, DataPublicacao) " +
                                           "VALUES (@ISBN, @Autor, @Nome, @Preco, @DataPublicacao)";

                SqlCommand cmdAdicionarLivro = new SqlCommand(SqlAdicionarLivro, con);
                cmdAdicionarLivro.CommandType = CommandType.Text;
                cmdAdicionarLivro.Parameters.AddWithValue("@ISBN", livro.ISBN);
                cmdAdicionarLivro.Parameters.AddWithValue("@Autor", livro.Autor);
                cmdAdicionarLivro.Parameters.AddWithValue("@Nome", livro.Nome);
                cmdAdicionarLivro.Parameters.AddWithValue("@Preco", livro.Preco);
                cmdAdicionarLivro.Parameters.AddWithValue("@DataPublicacao", livro.DataPublicacao);

                con.Open();

                try
                {
                    cmdAdicionarLivro.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Atualizar(Livro livro)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string SqlAtualizarLivro = "UPDATE LIVRO " +
                                           "SET Autor = @Autor, " +
                                           "Nome = @Nome, " +
                                           "Preco = @Preco, " +
                                           "DataPublicacao = @DataPublicacao " +
                                           "WHERE ISBN = @ISBN";

                SqlCommand cmdAtualizarLivro = new SqlCommand(SqlAtualizarLivro, con);
                cmdAtualizarLivro.CommandType = CommandType.Text;
                cmdAtualizarLivro.Parameters.AddWithValue("@ISBN", livro.ISBN);
                cmdAtualizarLivro.Parameters.AddWithValue("@Autor", livro.Autor);
                cmdAtualizarLivro.Parameters.AddWithValue("@Nome", livro.Nome);
                cmdAtualizarLivro.Parameters.AddWithValue("@Preco", livro.Preco);
                cmdAtualizarLivro.Parameters.AddWithValue("@DataPublicacao", livro.DataPublicacao);

                con.Open();

                try
                {
                    cmdAtualizarLivro.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Livro ObterLivroPorISBN(string isbn)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string SqlObterLivroPorISBN = "SELECT ISBN, Autor, Nome, Preco, DataPublicacao " +
                                              "FROM Livro WHERE ISBN = @ISBN";

                SqlCommand cmdObterLivroPorISBN = new SqlCommand(SqlObterLivroPorISBN, con);
                cmdObterLivroPorISBN.CommandType = CommandType.Text;
                cmdObterLivroPorISBN.Parameters.AddWithValue("@ISBN", isbn);

                con.Open();

                SqlDataReader rdr = cmdObterLivroPorISBN.ExecuteReader();

                Livro livro = null;
                while(rdr.Read())
                {
                    livro = new Livro(rdr["ISBN"].ToString(),
                                      rdr["Autor"].ToString(),
                                      rdr["Nome"].ToString(),
                                      Convert.ToDecimal(rdr["Preco"]),
                                      Convert.ToDateTime(rdr["DataPublicacao"]));
                }

                con.Close();

                return livro;
                
            }
        }

        public IEnumerable<Livro> ObterTodos()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string SqlObterTodos = "SELECT ISBN, Autor, Nome, Preco, DataPublicacao " +
                                        "FROM Livro";

                SqlCommand cmdObterTodosLivros = new SqlCommand(SqlObterTodos, con);
                cmdObterTodosLivros.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader rdr = cmdObterTodosLivros.ExecuteReader();

                List<Livro> livros = new List<Livro>();
                while (rdr.Read())
                {
                    Livro livro = new Livro(rdr["ISBN"].ToString(),
                                      rdr["Autor"].ToString(),
                                      rdr["Nome"].ToString(),
                                      Convert.ToDecimal(rdr["Preco"]),
                                      Convert.ToDateTime(rdr["DataPublicacao"]));

                    livros.Add(livro);
                }

                con.Close();

                return livros;
            }
        }

        public IEnumerable<Livro> Pesquisar(string tipoPesquisa, string valorPesquisa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string campoPesquisa = tipoPesquisa.ToUpper();

                switch(tipoPesquisa.ToUpper())
                {
                    case "ISBN":
                        campoPesquisa = "ISBN";
                        break;

                    case "AUTOR":
                        campoPesquisa = "Autor";
                        break;

                    case "NOME":
                        campoPesquisa = "Nome";
                        break;

                    case "PRECO":
                        campoPesquisa = "Preco";
                        break;

                    case "DATAPUBLICACAO":
                        campoPesquisa = "DataPublicacao";
                        break;
                }

                string SqlPesquisar = $"SELECT ISBN, Autor, Nome, Preco, DataPublicacao " +
                                      $"WHERE {campoPesquisa} like @valorPesquisa " +
                                      $"ORDER BY {campoPesquisa}";

                SqlCommand cmdPesquisar = new SqlCommand(SqlPesquisar, con);
                cmdPesquisar.CommandType = CommandType.Text;
                cmdPesquisar.Parameters.AddWithValue("@valorPesquisa", valorPesquisa + "%");

                con.Open();

                SqlDataReader rdr = cmdPesquisar.ExecuteReader();

                List<Livro> livros = new List<Livro>();
                while (rdr.Read())
                {
                    Livro livro = new Livro(rdr["ISBN"].ToString(),
                                      rdr["Autor"].ToString(),
                                      rdr["Nome"].ToString(),
                                      Convert.ToDecimal(rdr["Preco"]),
                                      Convert.ToDateTime(rdr["DataPublicacao"]));

                    livros.Add(livro);
                }

                con.Close();

                return livros;
            }
        }

        public void Remover(string isbn)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string SqlRemoverLivro = "DELETE FROM Livro WHERE ISBN = @ISBN";

                SqlCommand cmdRemoverLivro = new SqlCommand(SqlRemoverLivro, con);
                cmdRemoverLivro.CommandType = CommandType.Text;
                cmdRemoverLivro.Parameters.AddWithValue("@ISBN", isbn);

                con.Open();

                try
                {
                    cmdRemoverLivro.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
