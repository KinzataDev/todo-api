using System.Collections.Generic;

using TodoApi.Models;
namespace TodoApi.Data {
    public interface ITodoListRepository : IRepository<TodoList, long>
    {
        
    }
}