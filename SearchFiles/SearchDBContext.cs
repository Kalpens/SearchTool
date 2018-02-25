using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClassLibrary1;

namespace SearchFiles
{
    public class SearchDBContext : DbContext
    {
        public SearchDBContext() : base()
        {
        }

        public DbSet<Word> Word { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
