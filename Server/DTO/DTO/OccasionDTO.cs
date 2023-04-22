using System;

namespace DTO
{
    public class OccasionDTO
    {
        public int OccasionCode { get; set; }
        public int InviterCode { get; set; }
        public DateTime OccasionDate { get; set; }
        public string RecordFile { get; set; }
        public short Repetition { get; set; }
        public DateTime FirstMessage { get; set; }
        public int Range { get; set; }
        public int OccasionTypeCode { get; set; }

        public string TypeName { get; set; }
    }
}
