using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using TodoApi.Models;

namespace TodoApi.Data
{

  public class TodoContext : DbContext
  {
    ILogger<TodoContext> _logger;

    public TodoContext(DbContextOptions<TodoContext> options, ILogger<TodoContext> logger)
      : base(options)
    {
      _logger = logger;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<Item> Items { get; set; }
  }
}