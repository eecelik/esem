using Entities;
using System.Data.Entity;

namespace DataAccess.Concrete
{
    public class SqlContext:DbContext
    {
        public SqlContext() : base("EsemDB") { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<SaveProduct> SaveProducts { get; set; }
    }
}
