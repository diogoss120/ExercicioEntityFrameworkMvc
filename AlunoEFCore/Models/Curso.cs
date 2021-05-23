using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunoTeste.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage="O título é obrigatório")]
        [StringLength(100, MinimumLength=3, ErrorMessage="Nome deve ter entre 3 e 100 caracteres")]
        public string Titulo  { get; set; }
    }
}