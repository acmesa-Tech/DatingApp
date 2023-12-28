using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")] // http://localhost:5001/api/users
public class UsersController: ControllerBase
{
    private readonly DataContext _context;
    public UsersController(DataContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();
        
        return users;
    }

    [HttpGet("{id}")] // http://localhost:5001/api/users/2
    public ActionResult<AppUser> GetUser(int id)
    {
        return _context.Users.Find(id);
    }
}