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
using System.Windows.Shapes;

namespace RepEasyDesktop.View
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        ControlLogin control;
        public WindowLogin()
        {
            InitializeComponent();
            control = new ControlLogin();
        }

        private void ButtonEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxCpf.Text))
                return;

            if (String.IsNullOrEmpty(TextBoxSenha.Text))
                return;

            if (control.Logar(TextBoxCpf.Text, TextBoxSenha.Text))
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("CPF ou senha incorreto");
            }
                
        }
    }
}
