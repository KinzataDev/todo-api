using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Data {
        public class TodoListRepository : EntityFrameworkRepository<TodoList, long>, ITodoListRepository
    {
        private readonly TodoContext _dbContext;
        public TodoListRepository(TodoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}