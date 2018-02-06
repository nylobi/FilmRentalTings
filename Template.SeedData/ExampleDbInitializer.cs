using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.DataBase;
using Template.Model;
using System;

namespace Template.SeedData
{
    public class ExampleDbInitializer : DropCreateDatabaseAlways<ExampleDbContext>
    {
        private ExampleDbContext Context;
        protected override void Seed(ExampleDbContext context)
        {
            this.Context = context;
            var alie = AddNewCustomer("Alie Algol");
            var forrest = AddNewCustomer("Forrest Fortran");
            var james = AddNewCustomer("James Java");
            var tet = AddNewFilm("The Exploding Tire","Michael Bay", 3.99);
            var bt = AddNewFilm("BoomTown", "Michael Bay", 3.99);
            var kb = AddNewFilm("Kabuum", "Michael Bay", 2.95);
            AddNewRental(tet, alie, new DateTime (2018,01,29));
            AddNewRental(bt, forrest, new DateTime(2018, 01, 31));
        }

        private Customer AddNewCustomer(string name)
        {
            var c = new Customer()
            { FullName = name };
            Context.Customer.Add(c);
            Context.SaveChanges();
            return c;
        }
        private Film AddNewFilm(string title, string director, double price)
        {
            var f = new Film()
            {Title = title, Director = director, Price = price};
            Context.Film.Add(f);
            Context.SaveChanges();
            return f;
        }

        private void AddNewRental(Film f, Customer c, DateTime sr)
        {
            var r = new Rental()
            {Film = f, Customer = c, Startrental = sr};
            Context.Rental.Add(r);
            Context.SaveChanges();
        }
    }
}
