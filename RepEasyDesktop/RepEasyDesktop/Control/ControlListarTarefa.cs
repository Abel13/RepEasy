using RepEasyDesktop.Model;
using RepEasyDesktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    public class ControlListarTarefa
    {
        public List<Tarefa> GetDespesas()
        {
            using (var context = new Model.Model())
            {
                return (from d in context.Tarefas
                        orderby d.Data descending
                        select d).ToList();
            }
        }

        internal void NovaTarefa()
        {
            ControlDashboard.LoadWindow(new UserControlTarefa());
        }
    }
}
