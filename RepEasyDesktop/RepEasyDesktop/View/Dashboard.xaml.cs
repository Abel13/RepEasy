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
    /// Lógica interna para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        ControlDashboard control;

        public Dashboard()
        {
            InitializeComponent();

            control = new ControlDashboard(this);
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void grid_mouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListView_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void SelectMenuItem(object sender, SelectionChangedEventArgs e)
        {
            control.LoadWindow(ListViewMenuLateral.SelectedIndex);
        }
        
        private void btnGithubLink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Abel13/RepEasy");
        }
    }
}
