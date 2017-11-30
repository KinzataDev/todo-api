using System.Collections.Generic;

using TodoApi.Models;
namespace TodoApi.Data {
    public interface IUserRepository : IRepository<TodoList, long>
    {
        // Leave for TodoList specific requirements
    }
}