using RepEasyDesktop.Control;
using RepEasyDesktop.View;
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

namespace RepEasyDesktop
{
    /// <summary>
    /// Interaction logic for WindowCadastro.xaml
    /// </summary>
    public partial class WindowCadastro : Window
    {
        ControlCadastroMorador control;
        public WindowCadastro()
        {
            InitializeComponent();
            control = new ControlCadastroMorador();
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            var messageQueue = SnackbarThree.MessageQueue;

            DateTime dataNascimento;
            String nome = TextBoxNome.Text;
            String cpf = TextBoxCpf.Text;
            String senha = TextBoxSenha.Password;

            if (String.IsNullOrEmpty(nome))
            {
                TextBoxNome.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Nome não informado."));
                return;
            }

            if (String.IsNullOrEmpty(cpf))
            {
                TextBoxCpf.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("CPF não informado."));
                return;
            }

            if (String.IsNullOrEmpty(senha))
            {
                TextBoxSenha.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Senha não informada."));
                return;
            }

            if (String.IsNullOrEmpty(TextBoxConfirmaSenha.Password) || TextBoxConfirmaSenha.Password != senha)
            {
                TextBoxConfirmaSenha.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Confirmação diferente da senha informada!"));
                return;
            }
            
            if (DatePickerNascimento.SelectedDate == null)
            {
                DatePickerNascimento.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Data de nascimento não informada."));
                return;
            }
            else
            {
                 dataNascimento = DatePickerNascimento.SelectedDate.Value;
            }

            if (control.Cadastrar(TextBoxNome.Text, TextBoxCpf.Text, TextBoxSenha.Password, dataNascimento))
            {
                Voltar();
            }
            else
            {
                Task.Factory.StartNew(() => messageQueue.Enqueue("Erro no cadastro, tente novamente!"));
            }
        }

        private void Voltar()
        {
            WindowLogin login = new WindowLogin();
            login.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Voltar();
        }
    }
}
