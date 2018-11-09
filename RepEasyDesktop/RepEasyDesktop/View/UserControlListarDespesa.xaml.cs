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
    /// Interaction logic for UserControlListarDespesa.xaml
    /// </summary>
    public partial class UserControlListarDespesa : UserControl
    {
        ControlListarDespesa control; 
        public UserControlListarDespesa()
        {
            InitializeComponent();
            control = new ControlListarDespesa();

            ListViewDespesas.ItemsSource = control.GetDespesas();
        }

        private void ButtonIncluirDespesa_Click(object sender, RoutedEventArgs e)
        {
            control.NovaDespesa();
        }
    }
}
