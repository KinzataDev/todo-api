using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{

  [Route("api/[controller]")]
  public class UserController : Controller
  {

    ILogger<UserController> _logger;
    private readonly TodoContext _context;

    public UserController(ILogger<UserController> logger, TodoContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}", Name = "GetUser")]
    public IActionResult GetById(long id)
    {
        var user = _context.Users.FirstOrDefault(t => t.UserId == id);
        if (user == null)
        {
            return NotFound();
        }
        return new ObjectResult(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] User user)
    {
        if (user == null || user.UserId != id)
        {
            return BadRequest();
        }

        var updatedUser = _context.Users.FirstOrDefault(t => t.UserId == id);
        if (updatedUser == null)
        {
            return NotFound();
        }

        updatedUser.Name = user.Name;

        _context.Users.Update(updatedUser);
        _context.SaveChanges();
        return new NoContentResult();
    }
  }
}