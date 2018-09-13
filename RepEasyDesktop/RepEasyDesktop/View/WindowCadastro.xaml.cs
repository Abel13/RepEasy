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

namespace RepEasyDesktop
{
    /// <summary>
    /// Interaction logic for WindowCadastro.xaml
    /// </summary>
    public partial class WindowCadastro : Window
    {
        ControlCadastroMorador controlCadastroMorador;
        public WindowCadastro()
        {
            InitializeComponent();
            controlCadastroMorador = new ControlCadastroMorador();
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            //Validar dados
            controlCadastroMorador.Salvar("Abel", "08748424684", "1234", DateTime.Now);
        }
    }
}
