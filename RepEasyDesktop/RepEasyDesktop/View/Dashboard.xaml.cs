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
            int indice = ListViewMenuLateral.SelectedIndex;
            MoveSelecionadoMenu(indice);

            switch (indice)
            {
                case 0:
                    GridPrincipalDashboard.Children.Clear();
                    GridPrincipalDashboard.Children.Add( new UserControlPerfil());
                    break;
                case 1:
                    GridPrincipalDashboard.Children.Clear();
                    GridPrincipalDashboard.Children.Add(new UserControlListarTarefa());
                    break;

                case 2:
                    GridPrincipalDashboard.Children.Clear();
                    GridPrincipalDashboard.Children.Add(new UserControlListarDespesa());
                    break;
                case 3:
                    GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                case 4:
                    GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                case 5:
                    GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                case 6:
                    GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                default:
                    GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new WindowCadastro());
                    break;
            }

        }

        private void MoveSelecionadoMenu(int indice)
        {
            TransicaoSelectedItemMenuLateral.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0 ,(132 + (60 * indice)),0, 0);
        }

        private void btnGithubLink_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
