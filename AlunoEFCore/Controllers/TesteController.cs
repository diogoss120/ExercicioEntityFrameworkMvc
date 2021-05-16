using System;
using Microsoft.AspNetCore.Mvc;
using AlunoTeste.Data;
using System.Linq;
using AlunoTeste.Models;
using System.Data;

namespace AlunoTeste.Controllers
{
    public class TesteController : Controller
    {
        private readonly AlunoContext context;
        public TesteController(AlunoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var alunos = context.Alunos.ToList();
            return View(alunos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, Nome, Sexo, Email, Nascimento")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                context.Add(aluno);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = context.Alunos.SingleOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Nome, Sexo, Email, Nascimento")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Alunos.Update(aluno);
                    context.SaveChanges();
                }
                catch (DBConcurrencyException)
                {
                    bool alunoExists = context.Alunos.Any(a => a.Id == aluno.Id);
                    if (!alunoExists)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = context.Alunos.SingleOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirma(int? id)
        {
            var aluno = context.Alunos.SingleOrDefault(a => a.Id == id);
            context.Alunos.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aluno = context.Alunos.SingleOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
    }
}