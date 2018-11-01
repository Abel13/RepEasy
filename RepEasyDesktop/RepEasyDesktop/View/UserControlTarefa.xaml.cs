using System;
using RepEasyDesktop.Control;
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
    /// Interação lógica para UserControlTarefa.xam
    /// </summary>
    public partial class UserControlTarefa : UserControl
    {
        ControlTarefa controlTarefa;
        List<object> moradores;

        public UserControlTarefa()
        {
            InitializeComponent();
            controlTarefa = new ControlTarefa();
            ComboBoxListaMorador.ItemsSource = controlTarefa.ListarMoradores();
            moradores = new List<object>();

        }

        private void ButtonSalvarTarefa_Click(object sender, RoutedEventArgs e)
        {
            var messageQueue = SnackbarThree.MessageQueue;
            string titulo = TexBoxTituloTarefa.Text;
            string descricao = TextBoxDescricaoTarefa.Text;
            DateTime data = TextDataTarefa.SelectedDate.Value;
            



            if (String.IsNullOrEmpty(titulo))
            {
                TexBoxTituloTarefa.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Titulo da tarefa não informado."));
                return;
            }
            if (String.IsNullOrEmpty(descricao))
            {
                TextBoxDescricaoTarefa.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Descrição da tarefa não informada."));
                return;
            }
            if (TextDataTarefa.SelectedDate == null)
            {
                TextDataTarefa.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Data da tarefa não informada."));
                return;
            } 

            if( !(controlTarefa.CadastrarTarefa(titulo, descricao, data, moradores)))
            {
                Task.Factory.StartNew(() => messageQueue.Enqueue("Erro no cadastro, tente novamente!"));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridTabelaTarefas.ItemsSource = controlTarefa.ListarMoradores();
        }

        private void select_check_morador(object sender, RoutedEventArgs e)
        {
            bool participa = ((CheckBox)sender).IsChecked ?? false;
            if (participa)
                moradores.Add(((CheckBox)sender).DataContext);
            else
                moradores.Remove(((CheckBox)sender).DataContext);
        }
    }
}
