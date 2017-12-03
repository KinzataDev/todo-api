using Xunit;
using TodoApi.Data;
using TodoApi.Services;
using TodoApi.Models;
using Moq;

namespace TodoApi.Tests.Services.UserService
{
    public class UserService_FindUserById
    {

        [Fact]
        public void FindUserWithId()
        {
            Mock<IUserRepository> repository = new Mock<IUserRepository>();
            IUserService subject = new TodoApi.Services.UserService( repository.Object );

            User user = new User();
            user.Name = "TestName";
            user.UserId = 1;
            repository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(user);

            var result = subject.FindUserById(1);

            Assert.Equal("TestName", result.Name);
            Assert.Equal(1, result.UserId);
        }

        [Fact]
        public void CannotFindUserWithIdReturnsNull()
        {
            Mock<IUserRepository> repository = new Mock<IUserRepository>();
            IUserService subject = new TodoApi.Services.UserService( repository.Object );

            repository.Setup(repo => repo.GetById(It.IsAny<long>()));

            var result = subject.FindUserById(1);

            Assert.Null(result);
        }
    }
}
