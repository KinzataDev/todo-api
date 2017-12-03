using Xunit;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;
using Moq;

namespace TodoApi.Tests.Services.UserService
{
    public class UserService_FindUserByName
    {

        [Fact]
        public void FindUserByName()
        {
            Mock<IUserRepository> repository = new Mock<IUserRepository>();
            IUserService subject = new TodoApi.Services.UserService( repository.Object );

            User user1 = new User();
            user1.Name = "TestName";
            user1.UserId = 1;

            User user2 = new User();
            user2.Name = "NameSecond";
            user2.UserId = 2;

            User user3 = new User();
            user3.Name = "BillyBoBob";
            user3.UserId = 3;
            
            repository.Setup(repo => repo.GetEntities()).Returns(new List<User>(){
                user1, user2, user3
            }.AsQueryable());

            var result = subject.FindUserByName("Name");

            Assert.IsAssignableFrom<IEnumerable<User>>(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(user1, result);
            Assert.Contains(user2, result);
            Assert.DoesNotContain(user3, result);
        }
    }
}
