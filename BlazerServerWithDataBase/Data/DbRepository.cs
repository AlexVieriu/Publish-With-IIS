using Dapper;
using System.Data;
using BlazerServerWithDataBase.Models;
using Microsoft.Data.SqlClient;

namespace BlazerServerWithDataBase.Data;
public class DbRepository : IDbRepository
{
    private readonly IConfiguration _config;
    private const string conStringName = "Default";

    public DbRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<UserUI>> GetUsers()
    {
        var connectionstring = _config.GetConnectionString(conStringName);

        using IDbConnection connection = new SqlConnection(connectionstring);

        var records = await connection.QueryAsync<UserUI>("select * from Users");

        return records.ToList();
    }
}
