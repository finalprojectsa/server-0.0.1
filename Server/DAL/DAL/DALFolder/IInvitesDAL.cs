using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;
namespace DAL.DALFolder
{
    public interface IInvitesDAL
    {
        public List<Invites> GetAllInvites();
        public List<Invites> GetInvitesByOccasionCode(int occasionCode);
        public Invites GetInvitebyInviteeCode(int code);
        public List<Invites> AddInvitee(Invites newInvite);
        public List<Invites> AddInviteeList(List<Invites> newInviteList);
        public List<Invites> UpdateInvitee(Invites newInvite,int inviteeCode);
        //public void OverInvites();
    }
}
