using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace Template.Model
{
    public class Customer
    {
        #region injected services
        public IDomainObjectContainer Container { protected get; set; }

        public ExampleService ExampleService { set; protected get; }

        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string FullName { get; set; }
        public virtual int Age { get; set; }

        public Rental CreateNewRental()
        {
            
            var r = Container.NewTransientInstance<Rental>();
            r.Customer = this;
            return r;
        }

        public IQueryable<Rental> AllRentals()
        {
  
                var cid = Id;
                return Container.Instances<Rental>().Where(r => r.Customer.Id == cid);
            
        }

        private ICollection<Rental> _Rentals = new List<Rental>();
        [Eagerly(EagerlyAttribute.Do.Rendering)]
        [TableView(false, "Film", "Startrental", "RemainingTime", "Overdue")]
        public virtual ICollection<Rental> Rentals
        {
            get
            {
                return _Rentals;
            }
            set
            {
                _Rentals = value;
            }
        }
    }
}
