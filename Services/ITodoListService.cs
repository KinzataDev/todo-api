using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services {

    public interface ITodoListService
    {
        TodoList FindTodoListById( long id );
        IEnumerable<TodoList> GetAllTodoLists();
        IEnumerable<TodoList> FindTodoListByName( string text );
        IEnumerable<TodoList> FindTodoListByUserId( long id );
        
        void AddTodoList(TodoList todoList);
        TodoList UpdateTodoList(TodoList oldTodoList, TodoList newTodoList);
        void DeleteTodoList(TodoList todoList);
    }
}