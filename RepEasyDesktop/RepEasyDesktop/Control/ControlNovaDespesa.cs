using RepEasyDesktop.Model;
using RepEasyDesktop.View.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    public class ControlNovaDespesa
    {
        Model.Model context;
        public ControlNovaDespesa()
        {
            context = new Model.Model();
        }

        public List<Morador> CarregarParticipantes()
        {
            var participantes = (from m in context.Moradores
                           select m).ToList();

            return participantes;
        }

        internal bool Salvar(string descricao, string valor, DateTime dataCompra, object itensCompra, object participantes)
        {
            int totalParticipantes = ((List<object>)participantes).Count;
            decimal valorMorador = decimal.Parse(valor) / totalParticipantes;

            List<MoradorDespesa> moradoresDespesa = new List<MoradorDespesa>();
            List<Item> itens = new List<Item>();

            foreach (var item in (List<object>)participantes)
            {
                var morador = (Morador)item;

                if(morador.Id != 1)
                    moradoresDespesa.Add(new MoradorDespesa { Morador = morador.Id, Valor = valorMorador, Responsavel = 1 });
            }

            foreach (var item in (ObservableCollection<ViewModelItemCompra>)itensCompra)
            {
                itens.Add(new Item { Descricao = item.Descricao });
            }

            Despesa despesa = new Despesa
            {
                Descricao = descricao,
                Item = itens,
                Data = dataCompra,
                MoradorDespesa = moradoresDespesa,
                Valor = decimal.Parse(valor)
            };

            context.Despesas.Add(despesa);
            return context.SaveChanges() > 0;
        }
    }
}
