using Entities;
using System.Data.Entity;


namespace DataAccess.Concrete
{
    public class SqlContext:DbContext
    {
        public SqlContext() : base() { }

        public DbSet<Account> Accounts { get; set; }
    }
}
