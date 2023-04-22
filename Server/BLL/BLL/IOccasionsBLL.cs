
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Models;
using WebApiCore.Models;

namespace BLL
{
    public interface IOccasionBLL
    {
        public List<OccasionDTO> GetAllOccasionDTO();
        public List<OccasionDTO> AddOccasion(OccasionDTO o);
        public List<OccasionDTO> DeleteOccasion(int occasionCode);
        public List<OccasionDTO> UpdateOccasion(OccasionDTO o, int code);
        public List<OccasionDTO> GetOccasionByInviterCode(int inviterCode);

        public List<CallObject> OverOccasions();

    }
}
