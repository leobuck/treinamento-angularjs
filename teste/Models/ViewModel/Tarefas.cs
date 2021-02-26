using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models.ViewModel
{
    public class Tarefas
    {
        public Tarefas()
        {

        }

        public Tarefas(IEnumerable<Tarefa> tarefas)
        {
            this.ListaTarefas = tarefas;
        }

        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Tarefa> ListaTarefas { get; set; }
    }
}
