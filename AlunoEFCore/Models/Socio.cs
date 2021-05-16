using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoTeste.Models
{
    [Table("Socios")]
    public class Socio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DuracaoEmMeses { get; set; }

        [Required]
        public double TaxaDesconto { get; set; }
    }
}
