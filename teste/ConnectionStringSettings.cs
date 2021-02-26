using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;

public class ConnectionStringSettings : IConnectionStringSettings
{
    public string ConnectionString { get; set; }
    public string Name { get; set; }
    public string ProviderName { get; set; }
    public bool IsGlobal => false;
}

public class MySettings : ILinqToDBSettings
{
    public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

    public string DefaultConfiguration => "Main";
    public string DefaultDataProvider => "SqlServer";

    public IEnumerable<IConnectionStringSettings> ConnectionStrings
    {
        get
        {
            yield return
                new ConnectionStringSettings
                {
                    Name = "Main",
                    ProviderName = "SqlServer",
                    ConnectionString = @"Server=10.0.0.64;Database=treinamento;User Id=sa;Password=Admin...;"
                };
        }
    }
}