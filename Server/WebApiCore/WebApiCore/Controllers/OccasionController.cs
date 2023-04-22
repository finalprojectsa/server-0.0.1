using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using DAL.DALFolder;
using DAL.Models;
using BLL;

namespace WebApiCore.Controllers
{
    [Route("api/Occasion")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        IOccasionBLL iOccasionBLL;
        public OccasionController(IOccasionBLL iOccasionBLL)
        {
            this.iOccasionBLL = iOccasionBLL; 
        }
        // GET: api/Occasion
        //[HttpGet("GetAllOccasion")]
        //public IActionResult GetAllOccasion()
        //{
        //    return Ok(iOccasionBLL.GetAllOccasion());
        //}

        //GET: api/Occasion/5
        [HttpGet("GetOccasionByInviterCode/{code}")]
        public IActionResult GetOccasionByInviterCode(int code)
        {
            return Ok(iOccasionBLL.GetOccasionByInviterCode(code));
        }
        // GET: api/Occasion
        [HttpGet("OverOccasions")]
        public IActionResult OverOccasions()
        {
            var list = iOccasionBLL.OverOccasions();
            return Ok(list);
        }

        //POST: api/Occasion

        [HttpPost("AddOccasion")]
        public IActionResult AddOccasion([FromBody] OccasionDTO newOccasion)
        {
            return Ok(iOccasionBLL.AddOccasion(newOccasion));
        }

        //PUT: api/Occasion/5
        [HttpPut("UpdateOccasion/{code}")]
        public IActionResult UpdateOccasion(int code, [FromBody] OccasionDTO upOccasion)
        {
            return Ok(iOccasionBLL.UpdateOccasion(upOccasion, code));
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteOccasion/{code}")]
        public IActionResult DeleteOccasion(int code)
        {
            return Ok(iOccasionBLL.DeleteOccasion(code));
        }
    }
}
