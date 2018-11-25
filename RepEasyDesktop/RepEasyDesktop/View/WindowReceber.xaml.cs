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
    /// Lógica interna para WindowReceber.xaml
    /// </summary>
    public partial class WindowReceber : Window
    {
        

        ControlPerfil control;

        object Recebimento;

        public WindowReceber(object recebimento)
        {   
            control = new ControlPerfil();
            InitializeComponent();
            Recebimento = recebimento;
        }

        private void ButtonConfirmar_Click(object sender, RoutedEventArgs e)
        {   
            decimal valor = decimal.Parse(TextBoxValor.Text);
            var messageQueue = SnackbarThree.MessageQueue;


            if (String.IsNullOrEmpty(TextBoxValor.Text))
            {
                TextBoxValor.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Valor não informado"));
                return;
            }

            control.Receber(decimal.Parse(TextBoxValor.Text), Recebimento);
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
