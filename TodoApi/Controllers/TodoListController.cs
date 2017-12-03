using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;

namespace TodoApi.Controllers
{

  [Route("api/[controller]")]
  public class TodoListController : Controller
  {

    ILogger<TodoListController> _logger;
    private readonly ITodoListService _service;

    public TodoListController(ILogger<TodoListController> logger, ITodoListService service)
    {
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    /*
    GET
    api/todolist
     */
    public IEnumerable<TodoList> Index()
    {
        return _service.GetAllTodoLists();
    }

    [HttpGet("{id}", Name = "GetTodoList")]
    /*
    GET
    api/todolist/:id
     */
    public IActionResult GetById(long id)
    {
        var item = _service.FindTodoListById( id );
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }

    [HttpPost]
    /*
    POST
    api/todolist
     */
    public IActionResult Create([FromBody] TodoList todoList)
    {
        if (todoList == null)
        {
            return BadRequest();
        }
        
        _service.AddTodoList(todoList);

        return CreatedAtRoute("GetTodoList", new { id = todoList.TodoListId }, todoList);
    }

    [HttpPut("{id}")]
    /*
    PUT
    api/todolist/:id
     */
    public IActionResult Update(long id, [FromBody] TodoList todoList)
    {
        if (todoList == null || todoList.TodoListId != id)
        {
            return BadRequest();
        }

        var todo = _service.FindTodoListById( id );
        if (todo == null)
        {
            return NotFound();
        }

        _service.UpdateTodoList(todo, todoList);
        return new NoContentResult();
    }

    [HttpDelete("{id}")]
    /*
    DELETE
    api/todolist/:id
     */
    public IActionResult Delete(long id)
    {
        var todo = _service.FindTodoListById( id );
        if (todo == null)
        {
            return NotFound();
        }

        _service.DeleteTodoList(todo);
        return new NoContentResult();
    }
  }
}