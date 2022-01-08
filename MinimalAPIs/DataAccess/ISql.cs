namespace MinimalAPIs.DataAccess;
public interface ISql
{
    Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters);
    Task SaveData<T>(string procedure, T parameters);
}
