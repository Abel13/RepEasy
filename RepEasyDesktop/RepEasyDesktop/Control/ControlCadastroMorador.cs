using RepEasyDesktop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    public class ControlCadastroMorador
    {
        public void Salvar(string nome, string cpf, string senha, DateTime data)
        {
            Morador morador = new Morador() { Nome = nome, Cpf = cpf, Senha = senha, DataNascimento = data };

            Model m = new Model();

            m.Moradores.Add(morador);
            m.SaveChanges();
        }
    }
}
