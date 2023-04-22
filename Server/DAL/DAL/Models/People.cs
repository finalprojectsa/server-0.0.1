using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class People
    {
        public People()
        {
            InverseFatherCodeNavigation = new HashSet<People>();
            InverseFatherInLawCodeNavigation = new HashSet<People>();
        }

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

        public virtual People FatherCodeNavigation { get; set; }
        public virtual People FatherInLawCodeNavigation { get; set; }
        public virtual ICollection<People> InverseFatherCodeNavigation { get; set; }
        public virtual ICollection<People> InverseFatherInLawCodeNavigation { get; set; }
    }
}
