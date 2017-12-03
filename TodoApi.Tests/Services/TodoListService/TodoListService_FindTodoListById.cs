using Xunit;
using System.Collections.Generic;
using System.Linq;
using System;
using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;
using Moq;

namespace TodoApi.Tests.Services.TodoListService
{
    public class TodoListService_FindTodoListById
    {

        [Fact]
        public void FindTodoListById()
        {
            Mock<ITodoListRepository> repository = new Mock<ITodoListRepository>();
            ITodoListService subject = new TodoApi.Services.TodoListService( repository.Object );

            User user = new User();
            user.Name = "TestUser";
            user.UserId = 4;

            TodoList todoList = new TodoList();
            todoList.Name = "TestList";
            todoList.TodoListId = 1;
            todoList.UserId = 4;
            todoList.User = user;
            repository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(todoList);

            var result = subject.FindTodoListById(1);

            Assert.Equal("TestList", result.Name);
            Assert.Equal(1, result.TodoListId);
            Assert.Equal(4, result.UserId);

            Assert.Equal(user, result.User);
        }

        [Fact]
        public void CannotFindTodoListWithIdReturnsNull()
        {
            Mock<ITodoListRepository> repository = new Mock<ITodoListRepository>();
            ITodoListService subject = new TodoApi.Services.TodoListService( repository.Object );

            repository.Setup(repo => repo.GetById(It.IsAny<long>()));

            var result = subject.FindTodoListById(1);

            Assert.Null(result);
        }
    }
}
