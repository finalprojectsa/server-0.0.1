
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IInvitesBLL
    {
        public List<InvitesDTO> GetAllInvitesDTO();
        public List<InvitesDTO> GetInvitesByOccasionCode(int occasionCode);
        public InvitesDTO GetInvitebyInviteeCode(int code);
        public List<InvitesDTO> AddInvitee(InvitesDTO newInvite);
        public List<InvitesDTO> AddInviteeList(List<InvitesDTO> newInviteList);
        public List<InvitesDTO> UpdateInvitee(InvitesDTO newInvite, int inviteeCode);
    }
}
