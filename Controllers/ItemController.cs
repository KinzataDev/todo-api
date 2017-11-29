using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using TodoApi.Models;

namespace TodoApi.Controllers
{

  [Route("api/[controller]")]
  public class ItemController : Controller
  {

    ILogger<ItemController> _logger;
    private readonly TodoContext _context;

    public ItemController(ILogger<ItemController> logger, TodoContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Item> GetAll()
    {
        return _context.Items.ToList();
    }

    [HttpGet("{id}", Name = "GetItem")]
    public IActionResult GetById(long id)
    {
        var item = _context.Items.FirstOrDefault(t => t.ItemId == id);
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Item item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        _context.Items.Add(item);
        _context.SaveChanges();

        return CreatedAtRoute("GetItem", new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Item item)
    {
        if (item == null || item.ItemId != id)
        {
            return BadRequest();
        }

        var updatedItem = _context.Items.FirstOrDefault(t => t.ItemId == id);
        if (updatedItem == null)
        {
            return NotFound();
        }

        updatedItem.Description = item.Description;
        updatedItem.IsComplete  = item.IsComplete;

        _context.Items.Update(updatedItem);
        _context.SaveChanges();
        return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var item = _context.Items.FirstOrDefault(t => t.ItemId == id);
        if (item == null)
        {
            return NotFound();
        }

        _context.Items.Remove(item);
        _context.SaveChanges();
        return new NoContentResult();
    }
  }
}