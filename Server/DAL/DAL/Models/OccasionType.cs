using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class OccasionType
    {
        public OccasionType()
        {
            Occasions = new HashSet<Occasions>();
        }

        public int OccasionTypeCode { get; set; }
        public string OccasionTypename { get; set; }

        public virtual ICollection<Occasions> Occasions { get; set; }
    }
}
