using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.DALFolder;
using DAL.Models;
using DTO;

namespace BLL
{
    public class OccasionTypeBLL : IOccasionTypeBLL
    {
        IMapper imapper;
        IOccasionTypeDAL iOccasionTypeDAL;

        public OccasionTypeBLL(IOccasionTypeDAL iOccasionTypeDAL)
        {
            this.iOccasionTypeDAL = iOccasionTypeDAL;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Converter>());
            imapper = config.CreateMapper();
        }

        public List<OccasionTypeDTO> AddOccasionType(OccasionTypeDTO o)
        {
            OccasionType ot = imapper.Map<OccasionTypeDTO, OccasionType>(o);
            return imapper.Map<List<OccasionType>, List<OccasionTypeDTO>>(iOccasionTypeDAL.AddOccasionType(ot));
        }

        public List<OccasionTypeDTO> GetAllOccasionType()
        {
            return imapper.Map<List<OccasionType>,List<OccasionTypeDTO>>(iOccasionTypeDAL.GetAllOccasionTypes());
        }

        public OccasionTypeDTO GetOccasionTypeByCode(int code)
        {
            return imapper.Map<OccasionType, OccasionTypeDTO>(iOccasionTypeDAL.GetOccasionTypeByCode(code));
        }

        //public OccasionTypeDTO GetOccasionTypeCodeByOccasionName(string occasionName)
        //{
        //    return imapper.Map<OccasionType, OccasionTypeDTO>(iOccasionTypeDAL.GetOccasionTypeCodeByOccasionName(occasionName));
        //}
    }
}
