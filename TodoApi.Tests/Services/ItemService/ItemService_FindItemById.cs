using Xunit;
using System.Collections.Generic;
using System.Linq;
using System;
using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;
using Moq;

namespace TodoApi.Tests.Services.ItemService
{
    public class ItemService_FindItemById
    {

        [Fact]
        public void FindItemById()
        {
            Mock<IItemRepository> repository = new Mock<IItemRepository>();
            IItemService subject = new TodoApi.Services.ItemService( repository.Object );

            TodoList todoList = new TodoList();
            todoList.Name = "TestList";
            todoList.TodoListId = 2;

            Item item = new Item();
            item.Description = "I am a description";
            item.ItemId = 1;
            item.TodoListId = 2;
            item.TodoList = todoList;

            repository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(item);

            var result = subject.FindItemById(1);

            Assert.Equal("I am a description", result.Description);
            Assert.Equal(1, result.ItemId);
            Assert.Equal(2, result.TodoListId);

            Assert.Equal(todoList, result.TodoList);
        }

        [Fact]
        public void CannotFindTodoListWithIdReturnsNull()
        {
            Mock<IItemRepository> repository = new Mock<IItemRepository>();
            IItemService subject = new TodoApi.Services.ItemService( repository.Object );

            repository.Setup(repo => repo.GetById(It.IsAny<long>()));

            var result = subject.FindItemById(1);

            Assert.Null(result);
        }
    }
}
