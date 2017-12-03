using Xunit;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;
using Moq;

namespace TodoApi.Tests.Services.TodoListService
{
    public class TodoListService_FindTodoListByUserId
    {

        [Fact]
        public void FindTodoListByUserId()
        {
            Mock<ITodoListRepository> repository = new Mock<ITodoListRepository>();
            ITodoListService subject = new TodoApi.Services.TodoListService( repository.Object );

            TodoList todoList1 = new TodoList();
            todoList1.Name = "TestList";
            todoList1.TodoListId = 1;
            todoList1.UserId = 1;

            TodoList todoList2 = new TodoList();
            todoList2.Name = "ListSecond";
            todoList2.TodoListId = 2;
            todoList2.UserId = 1;

            TodoList todoList3 = new TodoList();
            todoList3.Name = "BillyBoBobTest";
            todoList3.TodoListId = 3;
            todoList3.UserId = 2;
            
            repository.Setup(repo => repo.GetEntities()).Returns(new List<TodoList>(){
                todoList1, todoList2, todoList3
            }.AsQueryable());

            var result = subject.FindTodoListByUserId(1);

            Assert.IsAssignableFrom<IEnumerable<TodoList>>(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(todoList1, result);
            Assert.Contains(todoList2, result);
            Assert.DoesNotContain(todoList3, result);
        }
    }
}
