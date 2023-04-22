using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;
namespace DAL.DALFolder
{
    public class InvitesDAL : IInvitesDAL
    {

        DBcontext DB;
        public InvitesDAL(DBcontext DB)
        {
            this.DB = DB;
        }
        public List<Invites> AddInvitee(Invites newInvite)
        {
            try
            {
                DB.Invites.Add(newInvite);
                DB.SaveChanges();
                return DB.Invites.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Invites> AddInviteeList(List<Invites> newInviteList)
        {
            foreach (var item in newInviteList)
            {
                AddInvitee(item);

            }
            return DB.Invites.ToList();
        }

        public List<Invites> GetAllInvites()
        {
            try
            {
                return DB.Invites.ToList();
            }
            catch (Exception)
            {

                return null ;
            }
        }

        public Invites GetInvitebyInviteeCode(int code)
        {
            try
            {
                Invites found = DB.Invites.ToList().Find(invitee => invitee.InviteeCode == code);
                return found;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Invites> GetInvitesByOccasionCode(int occasionCode)
        {
            try
            {
                List<Invites> found = DB.Invites.ToList().FindAll(invitee => invitee.OccasionCode == occasionCode);
                return found;

            }
            catch (Exception)
            {

                return null;
            }
        }

        //public void OverInvites()
        //{
        //    List<Invites> li = new List<Invites>();
        //    li = GetAllInvites();
        //    var x = li.Where(i => i.)
        //}

        public List<Invites> UpdateInvitee(Invites newInvite, int inviteeCode)
        {
            try
            {
                Invites found = DB.Invites.ToList().Find(invitee => invitee.InviteeCode == inviteeCode);
                found.Answerd = newInvite.Answerd;
                found.Portions = newInvite.Portions;
                found.ReminderDay = newInvite.ReminderDay;
                found.TryCount = newInvite.TryCount;
                DB.SaveChanges();
                return DB.Invites.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
