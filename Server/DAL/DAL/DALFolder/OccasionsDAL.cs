using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DAL.DALFolder
{
    public class OccasionsDAL : IOccasionsDAL
    {
        DBcontext DB;
        public OccasionsDAL(DBcontext DB)
        {
            this.DB = DB;
        }
        public List<Occasions> AddOccasion(Occasions o)
        {

            try
            {
                DB.Occasions.Add(o);
                DB.SaveChanges();
                return DB.Occasions.ToList();
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public List<Occasions> DeleteOccasion(int occasionCode)
        {
            try
            {
                Occasions o = DB.Occasions.ToList().Find(o => o.OccasionCode == occasionCode);
                DB.Occasions.Remove(o);
                DB.SaveChanges();
                return DB.Occasions.ToList();

            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Occasions> GetAllOccasions()
        {
            return DB.Occasions.ToList();
        }

        public List<Occasions> GetOccasionByInviterCode(int inviterCode)
        {
            try
            {
                List<Occasions> found = DB.Occasions.ToList().FindAll(o => o.InviterCode == inviterCode);
                return found;
            }
            catch (Exception)
            {

                return null;
            }

        }

       
        
        public List<Occasions> UpdateOccasion(Occasions o, int inviterCode)
        {
            try
            {
                Occasions found = DB.Occasions.ToList().Find(o => o.InviterCode == inviterCode);
                found.OccasionDate = o.OccasionDate;
                found.Range = o.Range;
                found.RecordFile = o.RecordFile;
                found.Repetition = o.Repetition;
                //found.OccasionTypeCode = o.OccasionTypeCode;
                found.FirstMessage = o.FirstMessage;
                return GetAllOccasions();
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
