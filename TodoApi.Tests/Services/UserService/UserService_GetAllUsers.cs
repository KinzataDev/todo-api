using Xunit;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;
using Moq;

namespace TodoApi.Tests.Services.UserService
{
    public class UserService_GetAllUsers
    {

        [Fact]
        public void GetAllUsers()
        {
            Mock<IUserRepository> repository = new Mock<IUserRepository>();
            IUserService subject = new TodoApi.Services.UserService( repository.Object );

            User user1 = new User();
            user1.Name = "TestName";
            user1.UserId = 1;

            User user2 = new User();
            user2.Name = "NameSecond";
            user2.UserId = 2;
            
            repository.Setup(repo => repo.GetEntities()).Returns(new List<User>(){
                user1, user2
            }.AsQueryable());

            var result = subject.GetAllUsers();

            Assert.IsAssignableFrom<IEnumerable<User>>(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("TestName", result.ElementAt(0).Name);
            Assert.Equal("NameSecond", result.ElementAt(1).Name);
        }
    }
}
