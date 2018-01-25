using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.DataBase;
using Template.Model;

namespace Template.SeedData
{
    public class ExampleDbInitializer : DropCreateDatabaseIfModelChanges<ExampleDbContext>
    {
        private ExampleDbContext Context;
        protected override void Seed(ExampleDbContext context)
        {
            this.Context = context;
            AddNewCustomer("Alie Algol");
            AddNewCustomer("Forrest Fortran");
            AddNewCustomer("James Java");
        }

        private void AddNewCustomer(string name)
        {
            var st = new Customer() { FullName = name };
            Context.Customer.Add(st);
        }
        private void AddNewFilm(string title)
        {
            var st = new Film() { Title = title };
            Context.Film.Add(st);
        }
    }
}
