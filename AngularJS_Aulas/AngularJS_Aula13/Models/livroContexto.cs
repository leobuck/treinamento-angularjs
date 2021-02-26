using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJS_Aula13.Models
{
    public class livroContexto : DbContext
    {
        public livroContexto() : base("name=LivrariaConnectionString")
        {
            Database.SetInitializer<livroContexto>(new livroDBInitializer());
        }
        public DbSet<Livro> livro { get; set; }
    }
}