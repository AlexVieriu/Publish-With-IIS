using MinimalAPIs.Models;

namespace MinimalAPIs;
public static class Api
{    
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoints
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users",InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);    
    }

    // if you have more then two lines in the API, put that in the Bussines Logic, a less in the API
    private static async Task<IResult> GetUsers(IUserData data)
    {
        try {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception e) {

            return Results.Problem($"{e.Message} - {e.InnerException}");
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try {
            var results = await data.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception e) {
            return Results.Problem($"{e.Message} - {e.InnerException}");
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try {
           await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception e) {

            return Results.Problem($"{e.Message} - {e.InnerException}");
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        try {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex) {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex) {

            return Results.Problem(ex.Message);
        }
    }
}
