using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace Template.Model
{
    public class Rental
    {
        #region injected services
        public IDomainObjectContainer Container {protected get; set; }

        public ExampleService ExampleService { set; protected get; }

        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Optionally][MemberOrder(1)]
        public virtual DateTime Startrental { get; set; }

        [Hidden(WhenTo.UntilPersisted)]
        public virtual int? RemainingTime
        {
            get
            {
                    var Endrental = Startrental.AddDays(7);
                    System.TimeSpan tl = Endrental.Subtract(DateTime.Today);
                return tl.Days;

                                   
            }
        }
        [Hidden(WhenTo.UntilPersisted)]

        public virtual string Overdue
        {
            get
            {
                var rb = new ReasonBuilder();
                rb.AppendOnCondition(RemainingTime < 0, "Overdue!");
                return rb.Reason;
            }
        }

        [Disabled(WhenTo.Always)]
        public virtual Customer Customer { get; set; }

        [PageSize(10)]
        public IQueryable<Customer> AutoCompleteCustomer(string matching)
        {
            return ExampleService.AllCustomers().Where(x => x.FullName.ToUpper().Contains(matching));
        }

        public virtual Film Film { get; set; }

        [PageSize(10)]
        public IQueryable<Film> AutoCompleteFilm(string matching)
        {
            return ExampleService.AllFilms().Where(x => x.Title.ToUpper().Contains(matching));
        }


        public override string ToString()
        {
            var tb = Container.NewTitleBuilder();
            tb.Append(Customer.FullName).Append(",").Append(Film.Title);
            return tb.ToString();
        }

        public string Validate(Customer customer, Film film)
        {
            var rb = new ReasonBuilder();
            rb.AppendOnCondition(film.AgeRating > customer.Age, "Not old enough");
            return rb.Reason;
        }


    }
}
