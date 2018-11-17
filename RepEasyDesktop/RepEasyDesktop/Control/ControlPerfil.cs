using RepEasyDesktop.Model;
using RepEasyDesktop.View.ViewModel;
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
            return Sessao.GetInstancia().Morador;
        }

        public bool Salvar(string nome, string senhaNova, DateTime data)
        {
            var id = Sessao.GetInstancia().Morador.Id;

            var morador = (from m in context.Moradores
                           where m.Id.Equals(id)
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

        public List<ViewModelSaldoMorador> CarregarSaldo()
        {
            using (var context = new Model.Model())
            {
                var id = Sessao.GetInstancia().Morador.Id;

                var listaSaldo = (from s in context.Recebimentos
                                  join m in context.Moradores on s.Devedor equals m.Id
                                  where s.Morador == id && s.Valor != 0
                                  select new { s.Devedor , m.Nome , s.Valor} ).ToList();

                List<ViewModelSaldoMorador> SaldoMoradores = new List<ViewModelSaldoMorador>();

                foreach (var item in listaSaldo)
                {
                    ViewModelSaldoMorador Saldo = new ViewModelSaldoMorador(item.Devedor, item.Nome, item.Valor); 

                    SaldoMoradores.Add(Saldo);
                    
                }

                return SaldoMoradores;
            }
        }

        public void Receber(decimal valor, object recebimento)
        {
            var saldoMorador = (ViewModelSaldoMorador)recebimento;

            var id = Sessao.GetInstancia().Morador.Id;

            using (var context = new Model.Model())
            {
                var dado1 = (from s in context.Recebimentos
                             where s.Morador1.Id.Equals(id) && s.Morador2.Id.Equals(saldoMorador.IdDevedor)
                            select s).FirstOrDefault();


                dado1.Valor += valor;

                var dado2 = (from s in context.Recebimentos
                            where s.Morador1.Id.Equals(saldoMorador.IdDevedor) && s.Morador2.Id.Equals(id)
                            select s).FirstOrDefault();


                dado2.Valor -= valor;

                context.SaveChanges();
            }

           
        }


    }
}
