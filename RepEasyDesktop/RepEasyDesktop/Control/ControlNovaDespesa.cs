using RepEasyDesktop.Model;
using System;
using System.Collections.Generic;
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
    }
}
