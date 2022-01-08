using System.Data;
using DataLibrary.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;


namespace DataLibrary.Data;

public class DataRepository : IDataRepository
{
    private readonly IConfiguration _config;
    private const string nameStringConnection = "ApptestSrv";

    public DataRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<User>> GetUsers()
    {
        var conectionstring = _config.GetConnectionString(nameStringConnection);
        //var conenctionstring = _config["ConnectionStrings:AppTestSrv"];

        using IDbConnection connection = new SqlConnection(conectionstring);

        var results = await connection.QueryAsync<User>("select * from users");

        return results.ToList();
    }
}
