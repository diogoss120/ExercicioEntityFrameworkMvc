using AlunoTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunoTeste.Data
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options)
        { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Socio> Socios { get; set; }
    }
}
