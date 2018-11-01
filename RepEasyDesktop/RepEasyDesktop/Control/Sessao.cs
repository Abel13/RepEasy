using RepEasyDesktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
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

        public void InserirMorador(Morador morador)
        {
            Morador = morador;
        }
    }
}
