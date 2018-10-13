using RepEasyDesktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    public class ControlLogin
    {
        Model.Model context;
        public ControlLogin()
        {
            context = new Model.Model();
        }
        public bool Logar(string cpf, string senha)
        {
            var morador = (from m in context.Moradores
                           where m.Cpf.Equals(cpf) && m.Senha.Equals(senha)
                           select m).FirstOrDefault();

            return morador != null;
        }
    }
}
