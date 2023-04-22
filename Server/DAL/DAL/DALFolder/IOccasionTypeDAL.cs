using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.DALFolder
{
    public interface IOccasionTypeDAL
    {
        public List<OccasionType> GetAllOccasionTypes();
        public List<OccasionType> AddOccasionType(OccasionType o);
        public OccasionType GetOccasionTypeByCode(int code);
        //public OccasionType GetOccasionTypeCodeByOccasionName(string occasionName);
    }
}
