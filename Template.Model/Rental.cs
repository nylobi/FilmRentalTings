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
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        public virtual DateTime Startrental { get; set; }
        public virtual DateTime Endrental { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Film Film { get; set; }
    }
}
