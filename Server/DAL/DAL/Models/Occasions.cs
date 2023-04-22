using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Occasions
    {
        public Occasions()
        {
            Invites = new HashSet<Invites>();
        }

        public int OccasionCode { get; set; }
        public int InviterCode { get; set; }
        public DateTime OccasionDate { get; set; }
        public string RecordFile { get; set; }
        public short Repetition { get; set; }
        public DateTime FirstMessage { get; set; }
        public int Range { get; set; }
        public int OccasionTypeCode { get; set; }

        public virtual OccasionType OccasionTypeCodeNavigation { get; set; }
        public virtual ICollection<Invites> Invites { get; set; }
    }
}
