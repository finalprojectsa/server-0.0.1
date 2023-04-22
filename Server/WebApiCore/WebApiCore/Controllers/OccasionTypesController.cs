using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.DALFolder;
using DAL.Models;
using BLL;
using DTO;

namespace WebApiCore.Controllers
{
    [Route("api/OccasionTypes")]
    [ApiController]
    public class OccasionTypesController : ControllerBase
    {
        IOccasionTypeBLL iOccasionTypeBLL;
        public OccasionTypesController(IOccasionTypeBLL iOccasionTypeBLL)
        {
            this.iOccasionTypeBLL = iOccasionTypeBLL;
        }
        // GET: api/OccasionTypes
        [HttpGet("GetAllOccasionType")]
        public IActionResult GetAllOccasionType()
        {
            return Ok(iOccasionTypeBLL.GetAllOccasionType());
        }

        // GET: api/OccasionTypes/5
        [HttpGet("GetOccasionTypeByCode/{code}")]
        public IActionResult GetOccasionTypeByCode(int code)
        {
            return Ok(iOccasionTypeBLL.GetOccasionTypeByCode(code));
        }

        //// GET: api/OccasionTypes/5
        //[HttpGet("GetOccasionTypeCodeByOccasionName/{occasionName}")]
        //public IActionResult GetOccasionTypeCodeByOccasionName(string occasionName)
        //{
        //    return Ok(iOccasionTypeBLL.GetOccasionTypeCodeByOccasionName(occasionName));
        //}

        // POST: api/OccasionTypes
        [HttpPost("AddOccasionType")]
        public IActionResult AddOccasionType([FromBody] OccasionTypeDTO newOccaasionType)
        {
            return Ok(iOccasionTypeBLL.AddOccasionType(newOccaasionType));
        }

        // PUT: api/OccasionTypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
