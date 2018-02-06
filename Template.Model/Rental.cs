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
#endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Optionally]
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


        public virtual Customer Customer { get; set; }

        public virtual Film Film { get; set; }
        public override string ToString()
        {
            var tb = Container.NewTitleBuilder();
            tb.Append(Customer).Append(",").Append(Film);
            return tb.ToString();
        }
        
    }
}
