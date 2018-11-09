using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RepEasyDesktop.View;

namespace RepEasyDesktop.Control
{
    public class ControlDashboard
    {
        public static Dashboard Dashboard { get; private set; }

        public ControlDashboard(Dashboard dashboard)
        {
            Dashboard = dashboard;
        }

        private void MoveSelecionadoMenu(int indice)
        {
            Dashboard.TransicaoSelectedItemMenuLateral.OnApplyTemplate();
            Dashboard.GridCursor.Margin = new Thickness(0, (132 + (60 * indice)), 0, 0);
        }

        internal void LoadWindow(int selectedIndex)
        {
            MoveSelecionadoMenu(selectedIndex);

            switch (selectedIndex)
            {
                case 0:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add( new UserControlNovaDespesa());
                    break;
                case 1:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    Dashboard.GridPrincipalDashboard.Children.Add(new UserControlTarefa());
                    break;

                case 2:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    Dashboard.GridPrincipalDashboard.Children.Add(new UserControlListarDespesa());
                    break;
                case 3:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                case 4:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                case 5:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                case 6:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new UserControlNovaDespesa());
                    break;
                default:
                    Dashboard.GridPrincipalDashboard.Children.Clear();
                    //GridPrincipalDashboard.Children.Add(new WindowCadastro());
                    break;
            }
        }

        public static void LoadWindow(UserControl userControl)
        {
            Dashboard.GridPrincipalDashboard.Children.Clear();
            Dashboard.GridPrincipalDashboard.Children.Add(userControl);
        }
    }
}
