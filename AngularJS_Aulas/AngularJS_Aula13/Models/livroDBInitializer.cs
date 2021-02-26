using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJS_Aula13.Models
{
    public class livroDBInitializer: CreateDatabaseIfNotExists<livroContexto>
    {
        protected override void Seed(livroContexto context)
        {
            IList<Livro> dados = new List<Livro>();

            dados.Add(new Livro() { Titulo = "Livro 1", Autor = "Autor 1" });
            dados.Add(new Livro() { Titulo = "Livro 2", Autor = "Autor 2" });
            dados.Add(new Livro() { Titulo = "Livro 3", Autor = "Autor 3" });

            foreach (Livro valor in dados)
                context.livro.Add(valor);

            base.Seed(context);
        }
    }
}