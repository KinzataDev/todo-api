using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using TodoApi.Models;

namespace TodoApi.Controllers
{

  [Route("api/[controller]")]
  public class ListController : Controller
  {

    ILogger<ListController> _logger;
    private readonly TodoContext _context;

    public ListController(ILogger<ListController> logger, TodoContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public IEnumerable<TodoList> GetAll()
    {
        return _context.TodoLists.ToList();
    }

    [HttpGet("{id}", Name = "GetTodoList")]
    public IActionResult GetById(long id)
    {
        var item = _context.TodoLists.FirstOrDefault(t => t.TodoListId == id);
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TodoList todoList)
    {
        if (todoList == null)
        {
            return BadRequest();
        }

        _context.TodoLists.Add(todoList);
        _context.SaveChanges();

        return CreatedAtRoute("GetTodoList", new { id = todoList.TodoListId }, todoList);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] TodoList todoList)
    {
        if (todoList == null || todoList.TodoListId != id)
        {
            return BadRequest();
        }

        var todo = _context.TodoLists.FirstOrDefault(t => t.TodoListId == id);
        if (todo == null)
        {
            return NotFound();
        }

        todo.Name = todoList.Name;

        _context.TodoLists.Update(todo);
        _context.SaveChanges();
        return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var todo = _context.TodoLists.FirstOrDefault(t => t.TodoListId == id);
        if (todo == null)
        {
            return NotFound();
        }

        _context.TodoLists.Remove(todo);
        _context.SaveChanges();
        return new NoContentResult();
    }
  }
}