using System;
using System.Collections.Generic;
using System.Text;
using DTO;
namespace BLL
{
    public interface IPeopleBLL
    {
        public List<PeopleDTO> GetAllPeople();
        public List<PeopleDTO> AddPerson(PeopleDTO p);
        public List<PeopleDTO> UpdatePerson(PeopleDTO p, int personCode);
        public PeopleDTO GetPersonByPhone(String phone);
        public List<PeopleDTO> GetPeopleByFatherCode(int fatherCode);
        public List<PeopleDTO> GetPeopleByFatherInLawCode(int fatherInLawCode);
        public List<PeopleDTO> GetPeopleByCity(String city);
        public List<PeopleDTO> GetPeopleByEducationPlace(String educationPlace);
        public List<PeopleDTO> GetPeopleByDavenPlace(String davenPlace);
        public List<string> GetDistinctAreaCode();
        public List<string> GetDistinctCity();
        public List<string> GetDistinctDavenPlace();
        public List<string> GetDistinctStudyPlace();
        public int GetHighestCode();
        public List<string> GetPhoneByPersonCode(int personCode);
    }
}
