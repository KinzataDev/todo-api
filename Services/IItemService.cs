using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services {

    public interface IItemService
    {
        Item FindItemById( long id );

        void AddItem(Item item);
        Item UpdateItem(Item oldItem, Item newItem);
        void DeleteItem(Item item);

        void ToggleCompleted( Item item );
        void ToggleCompleted( long id );
    }
}