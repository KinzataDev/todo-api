using System.Collections.Generic;

namespace TodoApi.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }

        public virtual List<TodoList> TodoLists { get; set; }
    }
}