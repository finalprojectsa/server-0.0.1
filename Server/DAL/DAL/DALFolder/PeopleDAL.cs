using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;

namespace DAL.DALFolder
{
    public class PeopleDAL : IPeopleDAL
    {
        DBcontext DB;
        public PeopleDAL(DBcontext DB)
        {
            this.DB = DB;
        }
        public List<People> AddPerson(People p)
        {
            try
            {
                this.DB.People.Add(p);
                DB.SaveChanges();
                return this.DB.People.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<People> GetAllPeople()
        {
            try
            {
                //this.DB.People.ToList().Sort((p1, p2) => p1.FirstName.CompareTo(p2.FirstName));
                //this.DB.People.ToList().Sort((p1,p2)=> p1.LastName.CompareTo(p2.LastName));
                return this.DB.People.OrderBy(p=>p.LastName + p.FirstName).ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<string> GetDistinctAreaCode()
        {
            List<string> list = new List<string>();
            try
            {
                var l = DB.People.
                    Where(p => p.Cellephone.Length >= 7 && p.Cellephone.CompareTo("000000000") != 0)
                    .Select(p => p.Cellephone.Substring(0, p.Cellephone.Length - 7))
                    .Union(DB.People
               
                    .Where(p => p.Telephone.Length >= 7 && p.Telephone.CompareTo("000000000") != 0)
                    .Select(p => p.Telephone.Substring(0, p.Telephone.Length - 7)))
                    .ToList();
                return l;
            }
            catch (Exception e)
            {
                
                return null;
            }
        }

        public List<string> GetDistinctCity()
        {
            try
            {
                var l = DB.People
                .Where(p => p.City != null)
                .Select(p => p.City)
                .Distinct().ToList().OrderBy(p => p).ToList();
                return l;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public List<string> GetDistinctDavenPlace()
        {
            try
            {
                var l = DB.People
                .Where(p => p.DavenPlace != null)
                .Select(p => p.DavenPlace)
                .Distinct().ToList().OrderBy(p=>p).ToList();
                return l;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<string> GetDistinctStudyPlace()
        {
            try
            {
                var l = DB.People
                .Where(p => p.EducationPlace != null)
                .Select(p => p.EducationPlace)
                .Distinct().ToList().OrderBy(p => p).ToList();
                return l;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public int GetHighestCode()
        {
            try
            {
                var l = DB.People.Max(p => p.PersonCode);
                return l;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public List<People> GetPeopleByCity(string city)
        {
            try
            {
                List<People> filteredList;
                filteredList = DB.People.ToList().FindAll(person => person.City == city);
                return filteredList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<People> GetPeopleByDavenPlace(string davenPlace)
        {
            try
            {
                List<People> filteredList;
                filteredList = DB.People.ToList().FindAll(person => person.DavenPlace == davenPlace);
                return filteredList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<People> GetPeopleByEducationPlace(string educationPlace)
        {
            try
            {
                List<People> filteredList;
                filteredList = DB.People.ToList().FindAll(person => person.EducationPlace == educationPlace);
                return filteredList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<People> GetPeopleByFatherCode(int fatherCode)
        {
            try
            {
                List<People> filteredList;
                filteredList = DB.People.ToList().FindAll(person => person.FatherCode == fatherCode);
                return filteredList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<People> GetPeopleByFatherInLawCode(int fatherInLawCode)
        {
            try
            {
                List<People> filteredList;
                filteredList = DB.People.ToList().FindAll(person => person.FatherInLawCode == fatherInLawCode);
                return filteredList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public People GetPersonByPhone(string phone)
        {
            try
            {
                People find;
                find = DB.People.ToList().Find(person => person.Telephone == phone || person.Cellephone == phone);
                return find;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<People> UpdatePerson(People p, int personCode)
        {
            try
            {
                People find;
                find = DB.People.ToList().Find(person => person.PersonCode == personCode);
                find.LastName = p.LastName;
                find.Street = p.Street;
                find.Cellephone = p.Cellephone;
                find.City = p.City;
                find.DavenPlace = p.DavenPlace;
                find.EducationPlace = p.EducationPlace;
                find.FirstName = p.FirstName;
                DB.SaveChanges();
                return DB.People.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<String> GetPhoneByPersonCode(int personCode)
        {
            try
            {
                People p = GetAllPeople().Find(p => p.PersonCode == personCode);
                List<String> phoneList = new List<String>();
                if(p.Cellephone != "")
                    phoneList.Add(p.Cellephone);
                if (p.Telephone != "")
                    phoneList.Add(p.Telephone);
                return phoneList;
            }
            catch (Exception)
            {

                return null;
            }
        }


    }
}
