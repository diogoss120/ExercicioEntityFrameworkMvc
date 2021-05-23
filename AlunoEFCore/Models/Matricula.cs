using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunoTeste.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Curso")]
        [Required(ErrorMessage ="Informe o curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        [Display(Name = "Aluno")]
        [Required(ErrorMessage = "Informe o aluno")]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "Informe a nota")]
        public Nota Nota {get; set;}
    }
}