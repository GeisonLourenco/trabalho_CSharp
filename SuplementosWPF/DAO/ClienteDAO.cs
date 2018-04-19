using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SuplementosWPF.Model;

namespace SuplementosWPF.DAO
{
    class ClienteDAO
    { 
            private static Context ctx = Singleton.Instance.Context;
            private static List<Cliente> clientes = new List<Cliente>();


            public static bool AdicionarCliente(Cliente cliente)
            {
                try
                {
                    ctx.Clientes.Add(cliente);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            public static bool RemoverCliente(Cliente cliente)
            {
                try
                {
                    ctx.Clientes.Remove(cliente);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            public static bool AlterarCliente(Cliente c)
            {
                try
                {
                    ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }

            public static Cliente BuscarCliente(Cliente cliente)
            {
                return ctx.Clientes.FirstOrDefault(x => x.CPF.Equals(cliente.CPF));
            }

            public static List<Cliente> RetornarLista()
            {
                return ctx.Clientes.ToList();
            }


        }
    }

