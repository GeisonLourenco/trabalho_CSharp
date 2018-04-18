using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuplementosWPF.Models;

namespace SuplementosWPF.DAO
{
    class SuplementoDAO
    {
        private static List<Suplemento> suplementos = new List<Suplemento>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarSuplemento(Suplemento suplemento)
        {
            try
            {
                ctx.Produtos.Add(suplemento);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static Suplemento BuscarSuplementoPorNome(Suplemento suplemento)
        {
            return ctx.Suplementos.FirstOrDefault(x => x.Nome.Equals(suplemento.Nome));
        }

        public static Suplemento BuscarSuplementoPorId(int suplementoId)
        {
            return ctx.Suplementos.FirstOrDefault(x => x.SuplementoId.Equals(SuplementoId));
        }

        public static List<Suplemento> RetornarLista()
        {
            return ctx.Suplementos.ToList();
        }
    }
}
