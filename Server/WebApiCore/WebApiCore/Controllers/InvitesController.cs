using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL.Models;
using DAL.DALFolder;
using DTO;

namespace WebApiCore.Controllers
{
    [Route("api/Invites")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        IInvitesBLL iInvitesBLL;
        public InvitesController(IInvitesBLL iInvitesBLL)
        {
            this.iInvitesBLL = iInvitesBLL;
        }
        // GET: api/Invites
        //[HttpGet("GetAllInvites")]
        //public IActionResult GetAllInvites()
        //{
        //    return Ok(iInvitesBLL.GetAllInvites());
        //}

        // GET: api/Invites/5
        [HttpGet("GetInvitesByOccasionCode/{code}")]
        public IActionResult GetInvitesByOccasionCode(int code)
        {
            return Ok(iInvitesBLL.GetInvitesByOccasionCode(code));
        }
        // GET: api/Invites/5
        [HttpGet("GetInvitebyInviteeCode/{code}")]
        public IActionResult GetInvitebyInviteeCode(int code)
        {
            return Ok(iInvitesBLL.GetInvitebyInviteeCode(code));
        }
        // POST: api/Invites
        [HttpPost("AddInvitee")]
        public IActionResult AddInvitee([FromBody] InvitesDTO newInvite)
        {
            return Ok(iInvitesBLL.AddInvitee(newInvite));
        }
        // POST: api/Invites
        [HttpPost("AddInviteeList")]
        public IActionResult AddInviteeList([FromBody] List<InvitesDTO> newInviteList)
        {
            foreach (var item in newInviteList)
            {
                AddInvitee(item);
            }
            return Ok(iInvitesBLL.GetAllInvitesDTO());
        }
        // PUT: api/Invites/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("UpdateInvitee/{id}")]
        public IActionResult UpdateInvitee(int code, InvitesDTO upInvite)
        {
            return Ok(iInvitesBLL.UpdateInvitee(upInvite, code));
        }
    }
}
