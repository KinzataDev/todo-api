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
    private readonly IUserRepository _repository;

    public UserController(ILogger<UserController> logger, IUserRepository repository)
    {
      _logger = logger;
      _repository = repository;
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
        // Return all
        return _repository.Find("");
    }

    [HttpGet("{id}", Name = "GetUser")]
    public IActionResult GetById(long id)
    {
        var user = _repository.GetById( id );
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

        var oldUser = _repository.GetById( id );
        if (oldUser == null)
        {
            return NotFound();
        }

        _repository.UpdateUser(oldUser, user);
        return new NoContentResult();
    }
  }
}