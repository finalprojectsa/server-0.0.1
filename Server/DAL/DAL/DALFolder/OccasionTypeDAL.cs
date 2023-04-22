using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;

namespace DAL.DALFolder
{
    public class OccasionTypeDAL : IOccasionTypeDAL
    {
        DBcontext DB;
        public OccasionTypeDAL(DBcontext DB)
        {
            this.DB = DB;
        }
        public List<OccasionType> AddOccasionType(OccasionType o)
        {
            try
            {
                DB.OccasionType.Add(o);
                DB.SaveChanges();
                return DB.OccasionType.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<OccasionType> GetAllOccasionTypes()
        {
            try
            {
                return DB.OccasionType.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public OccasionType GetOccasionTypeByCode(int  code)
        {
            try
            {
                OccasionType find = DB.OccasionType.ToList().Find(occasionType => occasionType.OccasionTypeCode == code);
                return find;
            }
            catch (Exception)
            {

                return null;
            }
        }
        //public OccasionType GetOccasionTypeCodeByOccasionName(string occasionName)
        //{
        //    try
        //    {
        //        OccasionType find = DB.OccasionType.ToList().Find(occasionType => occasionType.OccasionTypename.Equals(occasionName));
        //        return find;
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}
    }
}
