using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlunoTeste.Data;
using AlunoTeste.Models;
using AlunoTeste.ViewModels;

namespace ExercicioEntityFramework.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly AlunoContext _context;

        public MatriculaController(AlunoContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
            //var list = await _context.Alunos.Distinct().ToListAsync();

            var list = await _context.Matriculas.Select(m => m.Aluno).Distinct().ToListAsync();

            return View(list);
        }

        // GET: Matricula/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = _context.Matriculas.Where(m => m.AlunoId == id)
                .Include(m => m.Curso).Include(m => m.Aluno); //.Distinct();
            if (matricula == null)
            {
                return NotFound();
            }
            ViewBag.NomeAluno = matricula.Select(a => a.Aluno.Nome).First();
            return View(matricula);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            MatriculaViewModel viewModel = new MatriculaViewModel()
            {
                Alunos = _context.Alunos.ToList(),
                Cursos = _context.Cursos.ToList(),
                Notas = new List<Nota> { Nota.A, Nota.B, Nota.C, Nota.D, Nota.F },
            };
            return View(viewModel);
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] // [Bind("Id,Curso,Aluno,Nota")] 
        public async Task<IActionResult> Create([Bind("Id,Curso,Aluno,Nota")] Matricula matricula)
        {

            if (matricula.Aluno.AlunoId != null && matricula.Curso.CursoId != null && matricula.Nota != null)
            {
                Matricula _matricula = new Matricula()
                {
                    AlunoId = matricula.Aluno.AlunoId,
                    CursoId = matricula.Curso.CursoId,
                    Nota = matricula.Nota,
                };
                _context.Add(_matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            MatriculaViewModel viewModel = new MatriculaViewModel()
            {
                Aluno = new Aluno() { AlunoId = matricula.Aluno.AlunoId },
                Curso = new Curso() { CursoId = matricula.Curso.CursoId },
                Alunos = _context.Alunos.ToList(),
                Cursos = _context.Cursos.ToList(),
                Notas = new List<Nota> { Nota.A, Nota.B, Nota.C, Nota.D, Nota.F },
            };
            ViewBag.viewModel = viewModel;

            return View(viewModel);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nota")] Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
