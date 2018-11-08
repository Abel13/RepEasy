using RepEasyDesktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    class ControlPerfil
    {
        Model.Model context;

        public ControlPerfil()
        {
            context = new Model.Model();       
        }
        
        public Morador GetMorador()
        {
            return Sessao.instancia.Morador;
        }

        public bool Salvar(string nome, string senhaNova, DateTime data)
        {
            var morador = (from m in context.Moradores
                           where m.Id.Equals(Sessao.instancia.Morador.Id)
                           select m).FirstOrDefault();

            morador.Nome = nome;
            morador.Senha = senhaNova;
            morador.DataNascimento = data;

            return context.SaveChanges() > 0;

        }

        public bool ValidarSenha(string cpf, string senhaAtual)
        {
            var morador = (from m in context.Moradores
                           where m.Cpf.Equals(cpf) && m.Senha.Equals(senhaAtual)
                           select m).FirstOrDefault();

            return morador != null;
        }
    }
}
