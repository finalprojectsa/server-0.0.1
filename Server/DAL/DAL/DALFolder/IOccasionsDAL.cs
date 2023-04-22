using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.DALFolder
{
    public interface IOccasionsDAL
    {
        public List<Occasions> GetAllOccasions();
        public List<Occasions> AddOccasion(Occasions o);
        public List<Occasions> DeleteOccasion(int occasionCode);
        public List<Occasions> UpdateOccasion(Occasions o, int code);
        public List<Occasions> GetOccasionByInviterCode(int inviterCode);
        //public void OverOccasions();

    }
}
