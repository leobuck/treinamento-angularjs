using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace AngularJS_Aula12
{
    /// <summary>
    /// Summary description for ProdutosService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProdutosService : System.Web.Services.WebService
    {

        [WebMethod]
        public void getProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Produtos", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(dr["Id"]);
                    produto.Nome = dr["Nome"].ToString();
                    produto.Descricao = dr["Descricao"].ToString();
                    produto.Preco = Convert.ToDecimal(dr["Preco"]);
                    produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                    listaProdutos.Add(produto);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listaProdutos));
        }
    }
}
