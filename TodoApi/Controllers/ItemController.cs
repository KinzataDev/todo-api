using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{

  [Route("api/[controller]")]
  public class ItemController : Controller
  {

    ILogger<ItemController> _logger;
    private readonly IItemService _service;

    public ItemController(ILogger<ItemController> logger, IItemService service)
    {
      _logger = logger;
      _service = service;
    }

    [HttpGet("{id}", Name = "GetItem")]
    /*
    GET
    api/item/:id
     */
    public IActionResult GetById(long id)
    {
        var item = _service.FindItemById( id );
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }

    [HttpPost]
    /*
    POST
    api/item
     */
    public IActionResult Create([FromBody] Item item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        _service.AddItem( item );

        return CreatedAtRoute("GetItem", new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    /*
    PUT
    api/item/:id
     */
    public IActionResult Update(long id, [FromBody] Item item)
    {
        if (item == null || item.ItemId != id)
        {
            return BadRequest();
        }

        var oldItem = _service.FindItemById( id );
        if (oldItem == null)
        {
            return NotFound();
        }

        _service.UpdateItem(oldItem, item);
        return new NoContentResult();
    }

    [HttpDelete("{id}")]
    /*
    DELETE
    api/item/:id
     */
    public IActionResult Delete(long id)
    {
        var item = _service.FindItemById( id );
        if (item == null)
        {
            return NotFound();
        }

        _service.DeleteItem( item );
        return new NoContentResult();
    }

    [HttpPost]
    /*
    POST
    api/item/:id
     */
    public IActionResult ToggleCompleted( long id ) {
        var item = _service.FindItemById( id );
        if (item == null)
        {
            return NotFound();
        }
        _service.ToggleCompleted( item );
        return new NoContentResult();
    }
  }
}