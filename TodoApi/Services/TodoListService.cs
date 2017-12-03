using System.Collections.Generic;
using System;
using System.Linq;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _repository;

        public TodoListService(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public void AddTodoList(TodoList todoList)
        {
            _repository.Create(todoList);
        }

        public void DeleteTodoList(TodoList todoList)
        {
            _repository.Delete(todoList);
        }

        public TodoList FindTodoListById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TodoList> FindTodoListByName(string text)
        {
            return _repository.GetEntities().Where( list => list.Name.Contains( text )).ToList();
        }

        public IEnumerable<TodoList> FindTodoListByUserId(long id)
        {
            return _repository.GetEntities().Where( list => list.UserId == id ).ToList();
        }

        public IEnumerable<TodoList> GetAllTodoLists()
        {
            return _repository.GetEntities().ToList();
        }

        public TodoList UpdateTodoList(TodoList oldTodoList, TodoList newTodoList)
        {
                
            oldTodoList.Name = newTodoList.Name;
            oldTodoList.UserId = newTodoList.UserId;
            _repository.Update(oldTodoList);
            _repository.SaveChanges();
            return newTodoList;
        
        }
    }
}