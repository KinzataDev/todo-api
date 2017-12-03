using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TodoList
    {
        public long TodoListId { get; set; }
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }

        public long UserId { get; set; }
    }
}