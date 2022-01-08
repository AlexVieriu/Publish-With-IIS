namespace BlazorServer.Static;
public static class Endpoints
{
    public static string BaseUrl = $"https://localhost:7148"; // API
    //public static string BaseUrl = $"https://localhost:7043"; // MinimalAPIs
    //public static string BaseUrl = $"https://localhost:444"; // publish MinimalAPIs

    public static string GetUsers = $"{BaseUrl}/Users";
}
