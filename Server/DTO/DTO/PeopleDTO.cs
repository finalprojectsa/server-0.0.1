using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PeopleDTO
    {
        public int PersonCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Telephone { get; set; }
        public string Cellephone { get; set; }
        public int FatherCode { get; set; }
        public int FatherInLawCode { get; set; }
        public string EducationPlace { get; set; }
        public string DavenPlace { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
    }
}
