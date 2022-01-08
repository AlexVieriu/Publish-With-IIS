using BlazorServer.Models;

namespace BlazorServer.Servicies;

public interface IBaseRepository
{
    Task<List<UserUI>> GetAll();
}