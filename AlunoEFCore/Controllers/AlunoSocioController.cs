using AlunoTeste.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioEntityFramework.Controllers
{
    public class AlunoSocioController : Controller
    {
        private AlunoContext context;

        public AlunoSocioController(AlunoContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var alunos = context.Alunos.Include(a => a.Socio);
            return View(alunos);
        }
    }
}
