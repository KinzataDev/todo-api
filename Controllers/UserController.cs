using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using TodoApi.Services;
using TodoApi.Models;

namespace TodoApi.Controllers
{

  [Route("api/[controller]")]
  public class UserController : Controller
  {

    ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService service)
    {
      _logger = logger;
      _userService = service;
    }

    [HttpGet]
    /*
    GET
    api/user
     */
    public IEnumerable<User> GetAll()
    {
        return _userService.GetAllUsers();
    }

    [HttpGet("{id}", Name = "GetUser")]
    /*
    GET
    api/user/:id
     */
    public IActionResult GetById(long id)
    {
        var user = _userService.FindUserById( id );
        if (user == null)
        {
            return NotFound();
        }
        return new ObjectResult(user);
    }

    [HttpPut("{id}")]
    /*
    PUT
    api/user/:id
     */
    public IActionResult Update(long id, [FromBody] User user)
    {
        if (user == null || user.UserId != id)
        {
            return BadRequest();
        }

        var oldUser = _userService.FindUserById( id );
        if (oldUser == null)
        {
            return NotFound();
        }

        _userService.UpdateUser(oldUser, user);
        return new NoContentResult();
    }
  }
}