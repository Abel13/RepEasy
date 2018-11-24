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
        public ControlNovaDespesa()
        {

        }

        public List<Morador> CarregarParticipantes()
        {
            var Id = Sessao.GetInstancia().Morador.Id;

            using (var context = new Model.Model())
            {
                var participantes = (from m in context.Moradores
                                     where m.Id != Id
                                     select m).ToList();

                return participantes;
            }
        }

        internal bool Salvar(string descricao, string valor, DateTime dataCompra, object itensCompra, object participantes)
        {
            var morador = Sessao.GetInstancia().Morador;
            ((List<object>)participantes).Add(morador);

            int totalParticipantes = ((List<object>)participantes).Count;
            decimal valorMorador = decimal.Parse(valor) / totalParticipantes;

            List<MoradorDespesa> moradoresDespesa = new List<MoradorDespesa>();
            List<Item> itens = new List<Item>();
            List<Recebimento> recebimentos = new List<Recebimento>();

            using (var context = new Model.Model())
            {
                foreach (var item in (List<object>)participantes)
                {
                    var devedor = (Morador)item;

                    if (devedor.Id != morador.Id)
                    {
                        moradoresDespesa.Add(new MoradorDespesa { Morador = devedor.Id, Valor = valorMorador, Responsavel = morador.Id });

                        var recebimentoDevedor = (from r in context.Recebimentos
                                                  where r.Morador1.Id.Equals(devedor.Id) && r.Morador2.Id.Equals(morador.Id)
                                                  select r).FirstOrDefault();
                        if (recebimentoDevedor == null)
                        {
                            recebimentoDevedor = new Recebimento()
                            {
                                Devedor = devedor.Id,
                                Morador = morador.Id
                            };
                            context.Recebimentos.Add(recebimentoDevedor);
                        }
                        recebimentoDevedor.Valor -= valorMorador;


                        var recebimentoMorador = (from r in context.Recebimentos
                                                  where r.Morador1.Id.Equals(morador.Id) && r.Morador2.Id.Equals(devedor.Id)
                                                  select r).FirstOrDefault();
                        if (recebimentoMorador == null)
                        {
                            recebimentoMorador = new Recebimento()
                            {
                                Devedor = morador.Id,
                                Morador = devedor.Id
                            };
                            context.Recebimentos.Add(recebimentoMorador);
                        }
                        recebimentoMorador.Valor += valorMorador;
                    }
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
}
