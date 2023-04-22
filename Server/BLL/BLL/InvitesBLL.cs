using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.DALFolder;
using DAL.Models;
namespace BLL
{
    public class InvitesBLL : IInvitesBLL
    {
        IMapper imapper;
        IInvitesDAL iInvitesDAL;
        public InvitesBLL(IInvitesDAL iInvitesDAL)
        {
            this.iInvitesDAL = iInvitesDAL;

            var config = new MapperConfiguration(cnf => cnf.AddProfile<Converter>());
            imapper = config.CreateMapper();
        }
        public List<InvitesDTO> AddInvitee(InvitesDTO newInvite)
        {
            Invites i = imapper.Map<InvitesDTO, Invites>(newInvite);
            return imapper.Map<List<Invites>,List<InvitesDTO>>(iInvitesDAL.AddInvitee(i));
        }

        public List<InvitesDTO> AddInviteeList(List<InvitesDTO> newInviteList)
        {
            foreach (var item in newInviteList)
            {
                AddInvitee(item);
            }
            return imapper.Map<List<Invites>, List<InvitesDTO>>(iInvitesDAL.GetAllInvites());
        }

        public List<InvitesDTO> GetAllInvitesDTO()
        {
            return imapper.Map<List<Invites>, List<InvitesDTO>>(iInvitesDAL.GetAllInvites());
        }

        public InvitesDTO GetInvitebyInviteeCode(int code)
        {
            return imapper.Map<Invites, InvitesDTO>(iInvitesDAL.GetInvitebyInviteeCode(code));
        }

        public List<InvitesDTO> GetInvitesByOccasionCode(int occasionCode)
        {
            return imapper.Map<List<Invites>, List<InvitesDTO>>(iInvitesDAL.GetInvitesByOccasionCode(occasionCode));
        }

        public List<InvitesDTO> UpdateInvitee(InvitesDTO newInvite, int inviteeCode)
        {
            Invites i = imapper.Map<InvitesDTO, Invites>(newInvite);
            return imapper.Map<List<Invites>, List<InvitesDTO>>(iInvitesDAL.UpdateInvitee(i, inviteeCode));

        }
    }
}
