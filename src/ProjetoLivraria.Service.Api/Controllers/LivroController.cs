using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Domain.Interfaces;
using ProjetoLivraria.Service.Api.Adapters;
using ProjetoLivraria.Service.Api.Models;
using System.Collections.Generic;

namespace ProjetoLivraria.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : ControllerBase
    {

        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        // GET: api/Livro
        [HttpGet]
        public IEnumerable<LivroViewModel> Get()
        {
            List<LivroViewModel> livrosViewModel = new List<LivroViewModel>();

            foreach (var item in _livroRepository.ObterTodos())
                livrosViewModel.Add(LivroAdapter.ToViewModel(item));

            return livrosViewModel;
        }

        // GET: api/Livro/5
        [HttpGet("{id}", Name = "Get")]
        public LivroViewModel Get(string id)
        {
            return LivroAdapter.ToViewModel(_livroRepository.ObterLivroPorISBN(id));
        }

        // POST: api/Livro
        [HttpPost]
        public void Post([FromBody] LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                if (VerificarNaoDuplicidade(livroViewModel.ISBN))
                    _livroRepository.Adicionar(LivroAdapter.ToDomainModel(livroViewModel));
            }
                
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public void Put([FromBody] LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                if (VerificarNaoDuplicidade(livroViewModel.ISBN))
                    _livroRepository.Atualizar(LivroAdapter.ToDomainModel(livroViewModel));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _livroRepository.Remover(id);
        }

        public bool VerificarNaoDuplicidade(string isbn)
        {
            return _livroRepository.ObterLivroPorISBN(isbn) == null ? true : false;
        }
    }
}