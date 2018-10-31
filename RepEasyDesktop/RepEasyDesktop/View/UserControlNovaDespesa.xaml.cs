using RepEasyDesktop.Control;
using RepEasyDesktop.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UserControlNovaDespesa.xaml
    /// </summary>
    public partial class UserControlNovaDespesa : UserControl
    {
        ControlNovaDespesa control;
        ObservableCollection<ViewModelItemCompra> itensCompra;

        public UserControlNovaDespesa()
        {
            InitializeComponent();

            control = new ControlNovaDespesa();
            itensCompra = new ObservableCollection<ViewModelItemCompra>();

            ListViewItens.ItemsSource = itensCompra;
            ListViewParticipantes.ItemsSource = control.CarregarParticipantes();
        }

        private void ButtonIncluirItem_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBoxItem.Text))
            {
                itensCompra.Add(new ViewModelItemCompra { Descricao = TextBoxItem.Text });
                TextBoxItem.Text = string.Empty;
                TextBoxItem.Focus();
            }
        }
        
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var vm = (ViewModelItemCompra)((Button)sender).DataContext;
            itensCompra.Remove(vm);
        }
    }
}
