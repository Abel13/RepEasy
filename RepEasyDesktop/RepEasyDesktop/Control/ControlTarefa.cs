using RepEasyDesktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepEasyDesktop.Control
{

    class ControlTarefa
    {
        Model.Model context = new Model.Model();

        public bool CadastrarTarefa(string titulo, string descricao, DateTime data,List<object> morador)
        {
            List<Morador> moradores= new List<Morador>();
            foreach (var item in morador)
            {
                moradores.Add((Morador)item);
            }

            Tarefa tarefa = new Tarefa() { Titulo = titulo, Descricao = descricao ,Data=data,Morador = moradores};
            context.Tarefas.Add(tarefa);

            return context.SaveChanges() > 0;
        }


        public List<Morador> ListarMoradores()
        {
            var listaMoradores = (from m in context.Moradores
                                  select m).ToList();

            return listaMoradores;
        }
    }


}
