using BlazerServerWithDataBase.Models;

namespace BlazerServerWithDataBase.Data;

public interface IDbRepository
{
    Task<List<UserUI>> GetUsers();
}