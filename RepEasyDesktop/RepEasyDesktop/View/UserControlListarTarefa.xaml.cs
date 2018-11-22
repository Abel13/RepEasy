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
    /// Interaction logic for UserControlListarTarefa.xaml
    /// </summary>
    public partial class UserControlListarTarefa : UserControl
    {
        ControlListarTarefa control;
        public UserControlListarTarefa()
        {
            InitializeComponent();
            control = new ControlListarTarefa();

            ListViewTarefas.ItemsSource = control.GetDespesas();
        }

        private void ButtonIncluirTarefa_Click(object sender, RoutedEventArgs e)
        {
            control.NovaTarefa();
        }
    }
}
