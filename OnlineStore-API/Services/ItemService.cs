using Data;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Services
{
    public class ItemService : IItemService
    {
        private readonly IDbContext _context;

        public ItemService(IDbContext context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            Item item = _context.Items.Find(id);
            _context.Items.Remove(item);
        }

        public void EditItem(Item item)
        {
            //_context.Entry(item).State = EntityState.Modified;
            _context.Items.AddOrUpdate(item);
            _context.SaveChanges();
        }

        public Item GetItemById(int itemId)
        {
            var result = _context.Items.FirstOrDefault(x => x.Id == itemId);
            return result;
        }

        public IEnumerable<Item> GetItems()
        {
            var result = _context.Items.OrderBy(x => x.Id).ToList();
            return result;
        }

        public IQueryable<Item> GetItemsQueryable()
        {
            var result = _context.Items.OrderBy(x => x.Id).ToList().AsQueryable();
            return result;
        }

        public IEnumerable<Item> GetReservedItems()
        {
            var result = _context.Items.Where(x => x.IsReserved == true).OrderBy(x => x.Id).ToList();
            return result;
        }
    }
}