using LinqToDB.Mapping;
using System;

namespace teste.Models
{
    [Table("tarefa_rotulos")]
    public class TarefaRotulo
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_tarefa")]
        public int IdTarefa { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("cor")]
        public string Cor { get; set; }

    }
}
