using LinqToDB.Data;

namespace teste
{
    public class DbContext : DataConnection
    {
        public DbContext() : base("Main")
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
            
        }
    }
}
