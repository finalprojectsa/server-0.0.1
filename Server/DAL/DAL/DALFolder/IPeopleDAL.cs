using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.DALFolder
{
    public interface IPeopleDAL
    {
        public List<People> GetAllPeople();
        public List<People> AddPerson(People p);
        public List<People> UpdatePerson(People p,int personCode);
        public People GetPersonByPhone(string phone);
        public List<People> GetPeopleByFatherCode(int fatherCode);
        public List<People> GetPeopleByFatherInLawCode(int fatherInLawCode);
        public List<People> GetPeopleByCity(string city);
        public List<People> GetPeopleByEducationPlace(string educationPlace);
        public List<People> GetPeopleByDavenPlace(string davenPlace);
        public List<string> GetDistinctAreaCode();
        public List<string> GetDistinctCity();
        public List<string> GetDistinctDavenPlace();
        public List<string> GetDistinctStudyPlace();
        public int GetHighestCode();
        public List<String> GetPhoneByPersonCode(int personCode);
    }
}
