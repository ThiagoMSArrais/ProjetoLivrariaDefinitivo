using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Mvc.Global;
using ProjetoLivraria.Mvc.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjetoLivraria.Mvc.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult Index()
        {
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("Livro").Result;
            return View(reponse.Content.ReadAsAsync<IEnumerable<LivroViewModel>>().Result);
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("Livro/" + id.ToString()).Result;
            return View(reponse.Content.ReadAsAsync<LivroViewModel>().Result);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivroViewModel livroViewModel)
        {
            try
            {
                HttpResponseMessage reponse = GlobalVariables.WebApiClient.PostAsJsonAsync("Livro", livroViewModel).Result;
                TempData["MsgSucesso"] = "Criado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.GetAsync("Livro/" + id.ToString()).Result;
            return View(reponse.Content.ReadAsAsync<LivroViewModel>().Result);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LivroViewModel livroViewModel)
        {
            try
            {
                HttpResponseMessage reponse = GlobalVariables.WebApiClient.PutAsJsonAsync("Livro/" + livroViewModel.ISBN, livroViewModel).Result;
                TempData["MsgSucesso"] = "Editado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebApiClient.DeleteAsync("Livro/" + id.ToString()).Result;
            TempData["MsgSucesso"] = "Deletado com sucesso.";
            return RedirectToAction("Index");
        }
    }
}