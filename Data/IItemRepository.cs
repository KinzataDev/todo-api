using System.Collections.Generic;

using TodoApi.Models;
namespace TodoApi.Data {
    public interface IItemRepository : IRepository<Item, long>
    {
        
    }
}