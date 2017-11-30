using System.Collections.Generic;

using TodoApi.Models;
namespace TodoApi.Data {
    public interface IUserRepository : IRepository<User, long>
    {
        IEnumerable<User> Find(string text);
        void UpdateUser(User oldEntity, User newEntity);
    }
}