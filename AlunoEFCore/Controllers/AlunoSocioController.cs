using AlunoTeste.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 373e301a180c9c545ac917010d2a5ad2112e05fb

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
