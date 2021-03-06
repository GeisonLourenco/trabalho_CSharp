﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuplementosWPF.Model
{
    [Table("Funcionario")]
    class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Comissao { get; set; }

        public override string ToString()
        {
            return "\nNome: " + Nome + " CPF: " + CPF;
        }
    }
}
