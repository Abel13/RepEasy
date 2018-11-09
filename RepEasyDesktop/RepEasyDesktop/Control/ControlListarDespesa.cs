using RepEasyDesktop.Model;
using RepEasyDesktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    public class ControlListarDespesa
    {
        Model.Model context;
        public ControlListarDespesa()
        {
            context = new Model.Model();
        }

        public List<Despesa> GetDespesas()
        {
            return (from d in context.Despesas
                    orderby d.Data descending
                    select d).ToList();
        }

        internal void NovaDespesa()
        {
            ControlDashboard.LoadWindow(new UserControlNovaDespesa());
        }
    }
}
