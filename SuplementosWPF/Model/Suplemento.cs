using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuplementosWPF.Model
{
    [Table("Suplemento")]
    public class Suplemento
    {
        [Key]
        public int SuplementoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Markup { get; set; }

        public override string ToString()
        {
            return "\nNome: " + Nome + " Preço: " + Preco;
        }
    }
}