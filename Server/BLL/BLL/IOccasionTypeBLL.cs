
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
namespace BLL
{
    public interface IOccasionTypeBLL
    {
        public List<OccasionTypeDTO> GetAllOccasionType();
        public List<OccasionTypeDTO> AddOccasionType(OccasionTypeDTO o);
        public OccasionTypeDTO GetOccasionTypeByCode(int code);
        //public OccasionTypeDTO GetOccasionTypeCodeByOccasionName(string occasionName);
    }
}
