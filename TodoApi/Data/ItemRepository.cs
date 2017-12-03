using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Data {
        public class ItemRepository : EntityFrameworkRepository<Item, long>, IItemRepository
    {
        private readonly TodoContext _dbContext;
        public ItemRepository(TodoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}