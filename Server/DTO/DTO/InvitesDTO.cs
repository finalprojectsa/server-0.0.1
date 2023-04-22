using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class InvitesDTO
    {
        public int InviteeCode { get; set; }
        public int OccasionCode { get; set; }
        public int Portions { get; set; }
        public bool Answerd { get; set; }
        public DateTime? ReminderDay { get; set; }
        public int TryCount { get; set; }
        public int PersonCode { get; set; }
    }
}
