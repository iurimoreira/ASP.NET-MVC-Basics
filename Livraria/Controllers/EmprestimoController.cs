﻿using Livraria.Domain;
using Livraria.Models;
using Livraria.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Livraria.Controllers
{
    public class EmprestimoController : Controller
    {
        /*
        private readonly IEmprestimoRepository repositoryEmprestimos;

        public EmprestimoController(IEmprestimoRepository repository)
        {
          this.repositoryEmprestimos = repository;
        }
        */

        // GET: Emprestimo
        public ActionResult Index()
        {
            var repositoryEmprestimos = new EmprestimoRepository();

            var emprestimos = repositoryEmprestimos.GetAllEmprestimos();

            return View(
                emprestimos.Select(a => new EmprestimoViewModel()
                {
                    id = a.id,
                    dataEmprestimo = a.dataEmprestimo,
                    dataDevolucao = a.dataDevolucao,
                    idLivro = a.idLivro,
                    nomeDoLivro = a.nomeDoLivro
                }));
        }

        // GET: Emprestimo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emprestimo/Create
        [HttpPost]
        public ActionResult Create(EmprestimoViewModel emprestimo)
        {
            var repositoryEmprestimos = new EmprestimoRepository();

            if (ModelState.IsValid)
            {
                repositoryEmprestimos.CreateEmprestimo(new Domain.Emprestimo()
                {
                    id = emprestimo.id,
                    dataEmprestimo = emprestimo.dataEmprestimo,
                    dataDevolucao = emprestimo.dataDevolucao,
                    idLivro = emprestimo.idLivro
                });

                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        // GET: Emprestimo/Edit/5
        public ActionResult Edit(int id)
        {
            var repositoryEmprestimos = new EmprestimoRepository();

            var emprestimo = repositoryEmprestimos.GetEmprestimoById(id);

            EmprestimoViewModel emprestimoVM = new EmprestimoViewModel();

            emprestimoVM.id = emprestimo.id;
            emprestimoVM.dataEmprestimo = emprestimo.dataEmprestimo;
            emprestimoVM.dataDevolucao = emprestimo.dataDevolucao;
            emprestimoVM.idLivro = emprestimo.idLivro;

            return View(emprestimoVM);
        }

        // POST: Emprestimo/Edit/5
        [HttpPost]
        public ActionResult Edit(EmprestimoViewModel emprestimo, FormCollection collection)
        {
            var repositoryEmprestimos = new EmprestimoRepository();

            try
            {
                Domain.Emprestimo e = new Domain.Emprestimo();

                e.id = emprestimo.id;
                e.dataEmprestimo = emprestimo.dataEmprestimo;
                e.dataDevolucao = emprestimo.dataDevolucao;
                e.idLivro = emprestimo.idLivro;
               
                repositoryEmprestimos.UpdateEmprestimo(e);

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
            var repositoryEmprestimos = new EmprestimoRepository();

            try
            {
                repositoryEmprestimos.DeleteEmprestimo(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
