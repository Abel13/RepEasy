using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RepEasyDesktop.View.ViewModel
{
    class ViewModelSaldoMorador
    {
        public int IdDevedor { get; private set; }
        public string Nome { get; private set; }
        public string MensagemDivida { get; private set; }
        public decimal Valor { get; private set; }
        public Visibility Visibilidade { get; private set; }
        public Brush Cor { get; private set; }

        public ViewModelSaldoMorador(int id, string nome, decimal valor)
        {
            IdDevedor = id;
            Nome = nome;
            Valor = valor;

            if (valor >= 0)
            {
                MensagemDivida = "Me deve: ";
                Visibilidade = Visibility.Visible;
                Cor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                MensagemDivida = "Devo: ";
                Visibilidade = Visibility.Collapsed;
                Cor = new SolidColorBrush(Colors.Red);
                Valor = valor * -1;
            }
        }

    }
}
