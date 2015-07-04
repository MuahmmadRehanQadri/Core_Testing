
using System.Data.Entity;
using Core.Model;

namespace Core.Persistence
{
    public class Context: DbContext
    {
        public Context() : base("MyDB") { }
        public DbSet<Customer> Customers { get; set; } 
    }
}
