using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunoTeste.Models
{
    [Table("Socios")]
    public class Socio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Informe a quantidade de meses")]
        [Display(Name = "Meses")]
        public int DuracaoEmMeses { get; set; }

        [Required(ErrorMessage="Informe a taxa de desconto")]
        [Display(Name = "Desconto")]
        public double TaxaDesconto { get; set; }
    }
}
