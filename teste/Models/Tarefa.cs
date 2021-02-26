using LinqToDB.Mapping;
using System.Collections.Generic;

namespace teste.Models
{
    [Table("tarefas")]
    public class Tarefa
    {
        [Column("id"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Association(ThisKey = "Id", OtherKey = "IdTarefa")]
        public List<TarefaRotulo> Rotulos { get; set; } = new List<TarefaRotulo>();
    }
}
