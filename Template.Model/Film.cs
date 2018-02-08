using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace Template.Model
{
    public class Film
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string Title { get; set; }
        public virtual string Director { get; set; }
        public virtual double Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual string Genre { get; set; }
        public virtual int AgeRating { get; set; }

    }
}
