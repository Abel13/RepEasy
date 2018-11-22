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


        public List<Tarefa> ListarTarefas()
        {
            var listaTarefas = (from t in context.Tarefas select t).ToList();
            return listaTarefas;

        }

        public void NovaTarefa()
        {
            ControlDashboard.LoadWindow(new UserControlTarefa());
        }
    }
}
