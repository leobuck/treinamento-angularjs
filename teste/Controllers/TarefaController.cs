
using AutoMapper;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using teste.Models;
using teste.Models.ViewModel;

namespace teste.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly DbContext db;
        private readonly IMapper mapper;

        public TarefaController(DbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Tarefa> Get()
        {
            var tarefas = db.GetTable<Tarefa>()
                .LoadWith(t => t.Rotulos)
                .ToList();
            return tarefas;
        }

        [HttpGet("{id}")]
        public Tarefa Get(int id)
        {
            var tarefa = db.GetTable<Tarefa>()
                .LoadWith(t => t.Rotulos)
                .First(t => t.Id == id);
            return tarefa;
        }

        [HttpPost]
        public object Post([FromBody]Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                return new { id = Convert.ToInt32(db.InsertWithIdentity(tarefa)) };
            }

            return null;
        }

        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.BeginTransaction();
                    AtualizarRotulos(tarefa);

                    db.GetTable<Tarefa>()
                            .Where(t => t.Id == id)
                            .Set(t => t.Titulo, tarefa.Titulo)
                            .Set(t => t.Descricao, tarefa.Descricao)
                            .Update();
                    db.CommitTransaction();
                    return true;
                }
                catch
                {
                    db.RollbackTransaction();
                    throw;
                }
            }

            return false;
        }

        private void AtualizarRotulos(Tarefa tarefa)
        {
            db.GetTable<TarefaRotulo>()
                .Where(t => t.IdTarefa == tarefa.Id)
                .Delete();

            foreach (var rotulo in tarefa.Rotulos)
            {
                rotulo.Id = Guid.NewGuid();
                rotulo.IdTarefa = tarefa.Id;
                db.Insert(rotulo);
            }
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.GetTable<Tarefa>()
                    .Where(t => t.Id == id)
                    .Delete() > 0;
        }
    }
}