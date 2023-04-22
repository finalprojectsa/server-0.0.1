using System;
using System.Collections.Generic;
using System.Text;
using DAL.DALFolder;
using DAL.Models;

namespace DTO
{
    public class Converter : AutoMapper.Profile
    {

        public Converter()
        {
            CreateMap<PeopleDTO, People>();
            CreateMap<People, PeopleDTO>();
            //CreateMap<List<PeopleDTO>, List<People>>();
            //CreateMap<List<People>, List<PeopleDTO>>();

            CreateMap<OccasionDTO, Occasions>();
            CreateMap<Occasions, OccasionDTO>();
            //CreateMap<List<OccasionDTO>, List<Occasions>>();
            //CreateMap<List<Occasions>, List<OccasionDTO>>();


            CreateMap<OccasionTypeDTO, OccasionType>();
            CreateMap<OccasionType, OccasionTypeDTO>();
            //CreateMap<List<OccasionTypeDTO>, List<OccasionType>>();
            //CreateMap<List<OccasionType>, List<OccasionTypeDTO>>();

            CreateMap<InvitesDTO, Invites>();
            CreateMap<Invites, InvitesDTO>();
            //CreateMap<List<InvitesDTO>, List<Invites>>();
            //CreateMap<List<Invites>, List<InvitesDTO>>();
        }
    }
}
