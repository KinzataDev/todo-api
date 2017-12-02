using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Data {
        public class UserRepository : EntityFrameworkRepository<User, long>, IUserRepository
    {
        private readonly TodoContext _dbContext;
        public UserRepository(TodoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateUser(User oldEntity, User newEntity)
        {
            oldEntity.Name = newEntity.Name;
            Update(oldEntity);
            SaveChanges();
        }
    }
}