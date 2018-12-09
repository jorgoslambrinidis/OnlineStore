using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Data
{
    public class OnlineStoreInitializer : DropCreateDatabaseIfModelChanges<OnlineStoreContext>
    {
        protected override void Seed(OnlineStoreContext context)
        {
            base.Seed(context);
        }
    }
}