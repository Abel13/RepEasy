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
        List<object> participantes;

        public UserControlNovaDespesa()
        {
            InitializeComponent();

            control = new ControlNovaDespesa();
            itensCompra = new ObservableCollection<ViewModelItemCompra>();

            participantes = new List<object>();

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

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            var messageQueue = SnackbarThree.MessageQueue;

            DateTime dataCompra;

            if (String.IsNullOrEmpty(TextBoxDescricao.Text))
            {
                TextBoxDescricao.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Informe a descrição da despesa."));
                return;
            }

            if (String.IsNullOrEmpty(TextBoxValor.Text))
            {
                TextBoxValor.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Informe o valor da despesa."));
                return;
            }

            if (DatePickerCompra.SelectedDate == null)
            {
                DatePickerCompra.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Data da compra não informada."));
                return;
            }
            else
            {
                dataCompra = DatePickerCompra.SelectedDate.Value;
            }
            
            if(participantes.Count == 0)
            {
                TabablzControlDespesa.SelectedIndex = 2;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Selecione os participantes da despesa."));
                return;   
            }

            control.Salvar(TextBoxDescricao.Text, TextBoxValor.Text, dataCompra, ListViewItens.ItemsSource, participantes);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            bool participa = ((CheckBox)sender).IsChecked ?? false;
            if (participa)
                participantes.Add(((CheckBox)sender).DataContext);
            else
                participantes.Remove(((CheckBox)sender).DataContext);
        }
    }
}
