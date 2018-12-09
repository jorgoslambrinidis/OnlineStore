using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IItemService
    {
        void AddItem(Item item);
        void EditItem(Item item);
        void DeleteItem(int id);

        IEnumerable<Item> GetItems();
        IQueryable<Item> GetItemsQueryable();

        Item GetItemById(int itemId);
        IEnumerable<Item> GetReservedItems();
    }
}
