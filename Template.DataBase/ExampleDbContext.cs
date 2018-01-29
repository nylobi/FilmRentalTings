
using System.Data.Entity;
using Template.Model;

namespace Template.DataBase
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(string dbName, IDatabaseInitializer<ExampleDbContext> initializer) : base(dbName)
        {
            Database.SetInitializer(initializer);
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }

}
