using NakedObjects;
using System.Linq;


namespace Template.Model
{
    //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class ExampleService
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Customer CreateNewCustomer()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Customer>();
        }

        public IQueryable<Customer> AllCustomers()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Customer>();
        }

        public IQueryable<Customer> FindCustomerByName(string name)
        {
            //Filters students to find a match
            return AllCustomers().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }

        public Film CreateNewFilm()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Film>();
        }

        public IQueryable<Film> AllFilms()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Film>();
        }

        public IQueryable<Film> FindFilmByTitle(string title)
        {
            //Filters students to find a match
            return AllFilms().Where(c => c.Title.ToUpper().Contains(title.ToUpper()));
        }


    }

}
