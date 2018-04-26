using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SuplementosWPF.DAO;
using SuplementosWPF.Model;

namespace SuplementosWPF.View
{
    /// <summary>
    /// Interaction logic for frmCadastrarCliente.xaml
    /// </summary>
    public partial class frmCadastrarCliente : Window
    {
        private static Context context = Singleton.Instance.Context;
        private Cliente c;
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                c = new Cliente
                {
                    Nome = txtNome.Text,
                    CPF = txtCpf.Text
                };

                if (ClienteDAO.AdicionarCliente(c))
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Suplementos WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel adicionar o cliente!", "Suplementos WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "Suplementos WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            btnGravarCliente.IsEnabled = false;
            btnAlterar.IsEnabled = true;

            if (txtNome.Text.Trim().Count() > 0)
            {
                try
                {
                    var consulta = from c in context.Clientes
                                   where c.Nome.Contains(txtNome.Text)
                                   select c;
                    dgDados.ItemsSource = consulta.ToList();
                }
            catch
                {

                }
            }
            if (!string.IsNullOrEmpty(txtCpf.Text))
            {
                c = new Cliente
                {
                    CPF = txtCpf.Text
                };
                if ((c = ClienteDAO.BuscarCliente(c)) != null)
                {
                    txtNome.Text = c.Nome;
                    txtCpf.Text = c.CPF;
                }
                else
                {
                    MessageBox.Show("Não foi enconstrado o cliente!", "Suplementos WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos!", "Suplementos WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtNome.Focus();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                c.Nome = txtNome.Text;
                c.CPF = txtCpf.Text;

                if (ClienteDAO.AlterarCliente(c))
                {
                    MessageBox.Show("Cliente alterado com sucesso!", "Suplementos WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o cliente!", "Suplementos WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "Suplementos WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            c.Nome = txtNome.Text;
            c.CPF = txtCpf.Text;
            if (ClienteDAO.RemoverCliente(c))
            {
                MessageBox.Show("Contato removido com sucesso!", "Suplementos WPF",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}


   