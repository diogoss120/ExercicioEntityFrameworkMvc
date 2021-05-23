using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunoTeste.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public Aluno Aluno { get; set; }
        public Nota Nota {get; set;}
    }
}