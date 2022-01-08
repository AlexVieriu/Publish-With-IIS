using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IDataRepository _dataRepo;

    public UsersController(IDataRepository dataRepo)
    {
        _dataRepo = dataRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try {
            var users = await _dataRepo.GetUsers();
            if (users == null)
                return NotFound();

            return Ok(users);
        }
        catch (Exception ex) {
            return InternalError(ex);
        }
    }

    private ObjectResult InternalError(Exception e)
    {
        return StatusCode(500, $"{ e.Message} - { e.InnerException}");
    }
}
