using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuplementosWPF.DAO;
using SuplementosWPF.Models;

namespace SuplementosWPF.DAO
{
    class Dados
    {
            public static void Inicializar()
            {
                List<Cliente> clientes = new List<Cliente>
            {
                new Cliente()
                {
                    Nome = "João",
                    CPF = "1"
                },
                new Cliente()
                {
                    Nome = "José",
                    CPF = "2"
                },
                new Cliente()
                {
                    Nome = "Pedro",
                    CPF = "3"
                },
            };
                List<Funcionario> funcionarios = new List<Funcionario>
            {
                new Funcionario()
                {
                    Nome = "Felipe",
                    CPF = "4"
                },
                new Funcionario()
                {
                    Nome = "Augusto",
                    CPF = "5"
                },
                new Funcionario()
                {
                    Nome = "Cintia",
                    CPF = "6"
                },
            };
                List<Suplemento> suplementos = new List<Suplemento>
            {
                new Suplemento()
                {
                    Nome = "Whey",
                    Markup = 2,
                    Preco = 200
                },
                new Suplemento()
                {
                    Nome = "Caseina",
                    Markup = 3,
                    Preco = 250
                },
                new Suplemento
                {
                    Nome = "Creatina",
                    Markup = 4,
                    Preco = 100
                },
            };
                clientes.ForEach(x => ClienteDAO.AdicionarCliente(x));
                funcionarios.ForEach(x => VendedorDAO.AdicionarFuncionario(x));
                suplementos.ForEach(x => SuplementoDAO.AdicionarSuplemento(x));
            }
    }
}

