using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data {
        public class UserRepository : EntityFrameworkRepository<User, long>, IUserRepository
    {
        private readonly TodoContext _dbContext;
        public UserRepository(TodoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new User GetById(long id)
        {
            return DbContext.Set<User>().Include("TodoLists").FirstOrDefault(user => user.UserId == id);
        }
    }
}