using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Model
{
    public class Sessao
    {
        public static Sessao instancia;
        public Morador Morador { get; private set; }


        private Sessao()
        {

        }

      
        public static Sessao GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sessao();
                  
            }

            return instancia;
        }
    }
}
