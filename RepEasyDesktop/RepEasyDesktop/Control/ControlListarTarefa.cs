using RepEasyDesktop.Model;
using RepEasyDesktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    class ControlListarTarefa
    {
        Model.Model context;


        public ControlListarTarefa()
        {
            context = new Model.Model();

        }


        public ICollection<Tarefa> ListarTarefas()
        {
            var Morador = Sessao.GetInstancia().Morador;

            var listaTarefas = (from t in context.Moradores
                                where t.Id.Equals(Morador.Id)
                                select t.Tarefa).ToList();

            return listaTarefas[0];
        }

        public void NovaTarefa()
        {
            ControlDashboard.LoadWindow(new UserControlTarefa());
        }
    }
}
