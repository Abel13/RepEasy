using RepEasyDesktop.Control;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepEasyDesktop.View
{
    /// <summary>
    /// Interação lógica para UserControlPerfil.xam
    /// </summary>
    public partial class UserControlPerfil : UserControl
    {
        ControlPerfil control;

        object Morador { get; set; }

        public UserControlPerfil()
        {
            InitializeComponent();

            control = new ControlPerfil();
            Morador = control.GetMorador();
            StackPanelPerfil.DataContext = Morador;

        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            var messageQueue = SnackbarThree.MessageQueue;

            DateTime dataNascimento;
            String nome = TextBoxNome.Text;
            String cpf = TextBoxCpf.Text;
            String senhaAtual = TextBoxSenhaAtual.Password;
            String senhaNova = TextBoxSenhaNova.Password;

            if (String.IsNullOrEmpty(nome))
            {
                TextBoxNome.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Nome não informado."));
                return;
            }

            if (String.IsNullOrEmpty(senhaAtual))
            {
                TextBoxSenhaAtual.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Senha atual não informada."));
                return;
            }


            if (DatePickerNascimento.SelectedDate == null || DatePickerNascimento.SelectedDate > DateTime.Now)
            {
                DatePickerNascimento.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Data de nascimento inválida."));
                return;
            }
            else
            {
                dataNascimento = DatePickerNascimento.SelectedDate.Value;
            }

            if (!String.IsNullOrEmpty(TextBoxSenhaNova.Password))
            {
                if (!control.ValidarSenha(cpf, senhaAtual))
                {
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Senha atual inválida!"));
                    return;
                }
            }
            else {
                senhaNova = senhaAtual;
            }

            if (control.Salvar(nome, senhaNova, dataNascimento))
            {
                Task.Factory.StartNew(() => messageQueue.Enqueue("Perfil atualizado com sucesso!"));
                return;
            }
            else
            {
                Task.Factory.StartNew(() => messageQueue.Enqueue("Erro ao atualizar perfil, tente novamente!"));
                return;
            }
            
        }
    }
}
