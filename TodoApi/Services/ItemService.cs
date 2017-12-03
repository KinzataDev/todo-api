using System.Collections.Generic;
using System;
using System.Linq;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services {

    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository) {
            _repository = repository;
        }

        public void AddItem(Item item)
        {
            _repository.Create(item);
        }

        public void DeleteItem(Item item) {
            _repository.Delete(item);
        }

        public Item FindItemById(long id)
        {
            return _repository.GetById(id);
        }

        public void ToggleCompleted(Item item)
        {
            item.IsComplete = !item.IsComplete;
            _repository.Update(item);
            _repository.SaveChanges();
        }

        public void ToggleCompleted(long id)
        {
            ToggleCompleted(FindItemById(id));
        }

        public Item UpdateItem(Item oldItem, Item newItem)
        {
            oldItem.Description = newItem.Description;
            _repository.Update(oldItem);
            _repository.SaveChanges();

            return oldItem;
        }
    }
}