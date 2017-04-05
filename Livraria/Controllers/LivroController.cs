using Livraria.Models;
using Livraria.Repository;
using System.Linq;
using System.Web.Mvc;

namespace Livraria.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository repository;

        public LivroController(ILivroRepository repository)
        {
            this.repository = repository;
        }

        // GET: Livro
        public ActionResult Index()
        {
            //var repository = new LivroRepository();

            var livros = repository.GetAllLivros();
            return View(
                livros.Select(a => new LivroViewModel()
                {
                    id = a.id,
                    titulo = a.titulo,
                    autor = a.autor,
                    editora = a.editora,
                    ano = a.ano
                }));
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                //var repository = new LivroRepository();

                repository.CreateLivro(new Domain.Livro()
                {
                    id = livro.id,
                    titulo = livro.titulo,
                    autor = livro.autor,
                    editora = livro.editora,
                    ano = livro.ano


                });

                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            //var repository = new LivroRepository();

            var livro = repository.GetLivroById(id);

            LivroViewModel livroVM = new LivroViewModel();

            livroVM.id = livro.id;
            livroVM.titulo = livro.titulo;
            livroVM.autor = livro.autor;
            livroVM.editora = livro.editora;
            livroVM.ano = livro.ano;

            return View(livroVM);
        }


        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(LivroViewModel livro, FormCollection collection)
        {
            try
            {
                //var repository = new LivroRepository();

                Domain.Livro l = new Domain.Livro();

                l.id = livro.id;
                l.titulo = livro.titulo;
                l.autor = livro.autor;
                l.editora = livro.editora;
                l.ano = livro.ano;


                repository.UpdateLivro(l);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                //var repository = new LivroRepository();

                repository.DeleteLivro(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Detalhes(int id)
        {
            var repository = new LivroRepository();

            var livro = repository.GetLivroById(id);

            LivroViewModel livroVM = new LivroViewModel();

            livroVM.id = livro.id;
            livroVM.titulo = livro.titulo;
            livroVM.autor = livro.autor;
            livroVM.editora = livro.editora;
            livroVM.ano = livro.ano;

            return View(livroVM);
        }


    }
}
