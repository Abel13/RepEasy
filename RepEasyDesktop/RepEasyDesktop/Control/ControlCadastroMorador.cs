using RepEasyDesktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{
    public class ControlCadastroMorador
    {
        public bool Cadastrar(string nome, string cpf, string senha, DateTime data)
        {
            Morador morador = new Morador() { Nome = nome, Cpf = cpf, Senha = senha, DataNascimento = data };
            Model.Model m = new Model.Model();

            m.Moradores.Add(morador);
            return m.SaveChanges() > 0;
        }
    }
}
