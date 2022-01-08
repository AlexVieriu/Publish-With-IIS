using DataLibrary.Models;

namespace DataLibrary.Data;

public interface IDataRepository
{
    Task<List<User>> GetUsers();
}