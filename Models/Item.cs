

namespace TodoApi.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public long TodoListId{ get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}