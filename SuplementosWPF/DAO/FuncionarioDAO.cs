using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuplementosWPF.Models;

namespace SuplementosWPF.DAO
{
    class FuncionarioDAO
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarFuncionario(Funcionario funcionario)
        {
            try
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static Funcionario ProcurarFuncionarioPorCPF(Funcionario funcionario)
        {
            return ctx.Funcionarios.FirstOrDefault(x => x.CPF.Equals(funcionario.CPF));
        }

        public static List<Funcionario> RetornarLista()
        {
            return ctx.Funcionarios.ToList();
        }
    }
}
