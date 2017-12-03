using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data {
        public class TodoListRepository : EntityFrameworkRepository<TodoList, long>, ITodoListRepository
    {
        private readonly TodoContext _dbContext;
        public TodoListRepository(TodoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new TodoList GetById(long id)
        {
            return DbContext.Set<TodoList>().Include("Items").FirstOrDefault(todoList => todoList.TodoListId == id);
        }
    }
}