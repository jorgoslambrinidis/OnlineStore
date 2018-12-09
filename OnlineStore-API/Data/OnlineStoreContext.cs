using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Data
{
    public class OnlineStoreContext : DbContext, IDbContext 
    {
        public new Database Database { get; private set; }

        public OnlineStoreContext() : base("OnlineStoreDbContext")
        {
            Database.SetInitializer<OnlineStoreContext>(null);
        }

        #region Entities
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion


        public Database GetDatabase()
        {
            return this.Database;
        }

        public new DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return (new OnlineStoreContext().Entry(entity) as DbEntityEntry<T>);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}