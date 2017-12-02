using System.Collections.Generic;
using System.Linq;

using TodoApi.Models;
namespace TodoApi.Data {
    public interface IUserRepository : IRepository<User, long>
    {
        void UpdateUser(User oldEntity, User newEntity);
    }
}