using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace MinimalAPIs.DataAccess;
public class Sql : ISql
{
    private readonly IConfiguration _config;
    private const string connectionStringName = "Default";
    public Sql(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T,U>(string procedure, U parameters)
    {
        var connectionString = _config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        return await connection.QueryAsync<T>(procedure,
                                              parameters,
                                              commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string procedure, T parameters)
    {
        var connectionString = _config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync(procedure,
                                      parameters,
                                      commandType: CommandType.StoredProcedure);
    }
}
