using MinimalAPIs.Models;

namespace MinimalAPIs.DataRepository;
public class UserData : IUserData
{
    private readonly ISql _sql;

    public UserData(ISql sql)
    {
        _sql = sql;
    }

    public async Task<IEnumerable<UserModel>> GetUsers() =>
        await _sql.LoadData<UserModel, dynamic>("spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id) =>
        (await _sql.LoadData<UserModel, dynamic>("spUser_Get", new { IdUser = id }))
        .FirstOrDefault();

    public async Task InsertUser(UserModel user) =>
        await _sql.SaveData("spUser_Insert", new { user.FirstName, user.LastName });

    public async Task UpdateUser(UserModel user) =>
        await _sql.SaveData("spUser_Update", new { user.FirstName, user.LastName });

    public async Task DeleteUser(int id) =>
        await _sql.SaveData("spUser_Delete", new { id });
}
