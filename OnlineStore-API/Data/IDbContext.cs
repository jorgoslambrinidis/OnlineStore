using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Database GetDatabase();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Item> Items { get; set; }
        DbSet<User> Users { get; set; }
    }
}
