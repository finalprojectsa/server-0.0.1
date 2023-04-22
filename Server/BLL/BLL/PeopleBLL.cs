using System;
using System.Collections.Generic;
using DTO;
using AutoMapper;
using DAL.DALFolder;
using DAL.Models;
using System.Linq;

namespace BLL
{
    public class PeopleBLL : IPeopleBLL
    {
        IMapper iMapper;
        IPeopleDAL iPeopleDAL;
        public PeopleBLL(IPeopleDAL iPeopleDAL)
        {
            this.iPeopleDAL = iPeopleDAL;
            var config = new MapperConfiguration(conf => conf.AddProfile<Converter>());
            this.iMapper = config.CreateMapper();
        }
        public List<PeopleDTO> AddPerson(PeopleDTO p)
        {
            People newP = iMapper.Map<PeopleDTO, People>(p);
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.AddPerson(newP).ToList());
        }

        public List<PeopleDTO> GetAllPeople()
        {
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.GetAllPeople().ToList());
        }

        public List<string> GetDistinctAreaCode()
        {
            var l =  iPeopleDAL.GetDistinctAreaCode();
            return l;
        }

        public List<PeopleDTO> GetPeopleByCity(string city)
        {
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.GetPeopleByCity(city).ToList());
        }

        public List<PeopleDTO> GetPeopleByDavenPlace(string davenPlace)
        {
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.GetPeopleByDavenPlace(davenPlace).ToList());
        }

        public List<PeopleDTO> GetPeopleByEducationPlace(string educationPlace)
        {
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.GetPeopleByEducationPlace(educationPlace).ToList());
        }

        public List<PeopleDTO> GetPeopleByFatherCode(int fatherCode)
        {
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.GetPeopleByFatherCode(fatherCode).ToList());
        }

        public List<PeopleDTO> GetPeopleByFatherInLawCode(int fatherInLawCode)
        {
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.GetPeopleByFatherInLawCode(fatherInLawCode).ToList());
        }
        public PeopleDTO GetPersonByPhone(string phone)
        {
            return iMapper.Map<People, PeopleDTO>(iPeopleDAL.GetPersonByPhone(phone));
        }

        public List<PeopleDTO> UpdatePerson(PeopleDTO p, int personCode)
        {
            People newP = iMapper.Map<PeopleDTO, People>(p);
            return iMapper.Map<List<People>, List<PeopleDTO>>(iPeopleDAL.UpdatePerson(newP,personCode).ToList());
        }

        public int GetHighestCode()
        {
            return iPeopleDAL.GetHighestCode();
        }

        public List<string> GetDistinctCity()
        {
            return iPeopleDAL.GetDistinctCity();
        }

        public List<string> GetDistinctDavenPlace()
        {
            return iPeopleDAL.GetDistinctDavenPlace();
        }

        public List<string> GetDistinctStudyPlace()
        {
            return iPeopleDAL.GetDistinctStudyPlace();        
        }

        public List<string> GetPhoneByPersonCode(int personCode)
        {
            return iPeopleDAL.GetPhoneByPersonCode(personCode);
        }

    }
}
