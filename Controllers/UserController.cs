using Microsoft.AspNetCore.Mvc;

namespace bank_api;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DatabaseBank _context;

    public UserController(DatabaseBank context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new {Mensagem = "Created User!", User = user});
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }
    

}
