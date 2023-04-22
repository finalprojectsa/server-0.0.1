
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DAL.DALFolder;
using DAL.Models;
using DTO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WebApiCore.Models;

namespace BLL
{
    public class OccasionsBLL : IOccasionBLL
    {
        IMapper imapper;
        IOccasionsDAL iOccasionDAL;

        IInvitesBLL invitesBLL;
        IPeopleBLL peopleBLL;
        public OccasionsBLL(IOccasionsDAL iOccasionDAL, IPeopleBLL peopleBLL, IInvitesBLL invitesBLL)
        {
            this.invitesBLL = invitesBLL;
            this.peopleBLL = peopleBLL;
            this.iOccasionDAL = iOccasionDAL;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Converter>());
            imapper = config.CreateMapper();
        }

        public List<OccasionDTO> AddOccasion(OccasionDTO o)
        {
            Occasions oc = imapper.Map<OccasionDTO, Occasions>(o);
            return imapper.Map<List<Occasions>, List<OccasionDTO>>(iOccasionDAL.AddOccasion(oc));
        }

        public List<OccasionDTO> DeleteOccasion(int occasionCode)
        {
            return imapper.Map<List<Occasions>, List<OccasionDTO>>(iOccasionDAL.DeleteOccasion(occasionCode));
        }

        public List<OccasionDTO> GetAllOccasionDTO()
        {
            return imapper.Map<List<Occasions>, List<OccasionDTO>>(iOccasionDAL.GetAllOccasions());
        }

        public List<OccasionDTO> GetOccasionByInviterCode(int inviterCode)
        {
            return imapper.Map<List<Occasions>, List<OccasionDTO>>(iOccasionDAL.GetOccasionByInviterCode(inviterCode));
        }

        public List<OccasionDTO> UpdateOccasion(OccasionDTO o, int code)
        {
            Occasions update = imapper.Map<OccasionDTO, Occasions>(o);
            return imapper.Map<List<Occasions>, List<OccasionDTO>>(iOccasionDAL.UpdateOccasion(update, code));
        }

        public List<CallObject> OverOccasions()
        {
            List<Occasions> allOccasions = iOccasionDAL.GetAllOccasions();
            var occasionsOfCurrentHour = allOccasions.Where(i => i.FirstMessage.Hour.Equals(DateTime.Now.Hour)).ToList();
            List<InvitesDTO> invitesListForSingleOccasion = new List <InvitesDTO>();
            List<int> personCodeList = new List<int>();
            List<string> phoneList = new List<string>();
            List<PeopleDTO> peopleList = peopleBLL.GetAllPeople();
            List<CallObject> calls = new List<CallObject>();
            foreach (var singleOccasion in occasionsOfCurrentHour)
            {
                invitesListForSingleOccasion = invitesBLL.GetInvitesByOccasionCode(singleOccasion.OccasionCode);
                foreach (var i in invitesListForSingleOccasion)
                {
                    personCodeList.Add(i.PersonCode);
                }
                foreach(var pCode in personCodeList)
                {
                    var list = new List<String>();
                    list = peopleBLL.GetPhoneByPersonCode(pCode);
                    foreach (var item in list)
                    {
                        phoneList.Add(item);
                    }   
                }
                foreach (var item in phoneList)
                {
                    CallObject call = new CallObject();
                    call.Record = singleOccasion.RecordFile;
                    call.Phone = item;
                    calls.Add(call);
                }
            }
            return calls;
        }
    }
}
