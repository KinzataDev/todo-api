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
    public class ItemService_ToggleCompleted
    {

        [Fact]
        public void ToggleCompleted_Item()
        {
            Mock<IItemRepository> repository = new Mock<IItemRepository>();
            IItemService subject = new TodoApi.Services.ItemService( repository.Object );

            Item item = new Item();
            item.Description = "I am a description";
            item.ItemId = 1;
            item.IsComplete = false;

            repository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(item);

            subject.ToggleCompleted(item);

            Assert.Equal(true, item.IsComplete);
        }

        [Fact]
        public void ToggleCompleted_Id()
        {
            Mock<IItemRepository> repository = new Mock<IItemRepository>();
            IItemService subject = new TodoApi.Services.ItemService( repository.Object );

            Item item = new Item();
            item.Description = "I am a description";
            item.ItemId = 1;
            item.IsComplete = false;

            repository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(item);

            subject.ToggleCompleted(item.ItemId);

            Assert.Equal(true, item.IsComplete);
        }
    }
}
