namespace Data.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.OnlineStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.OnlineStoreContext context)
        {
            var items = new List<Item>
            {
                new Item {Name = "Tablet", Price = 100, Description = "asd", IsReserved = true, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Phone Case", Price = 20, Description = "qwe", IsReserved = false, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "TV", Price = 300, Description = "ert", IsReserved = true, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Phone", Price = 350, Description = "xcv", IsReserved = false, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Monitor", Price = 130, Description = "zxc", IsReserved = true, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Sound Bar", Price = 200, Description = "rty", IsReserved = false, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Smart Watch", Price = 220, Description = "ghj", IsReserved = true, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Wireless Earbuds", Price = 55, Description = "bnm", IsReserved = false, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Laptop", Price = 500, Description = "iop", IsReserved = true, NumberOfItems = 100, Date = DateTime.Now},
                new Item {Name = "Surround System", Price = 470, Description = "fgh", IsReserved = false, NumberOfItems = 100, Date = DateTime.Now}
            };

            items.ForEach(s => context.Items.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
