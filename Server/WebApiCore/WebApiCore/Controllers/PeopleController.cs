using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO;

namespace WebApiCore.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPeopleBLL ipeopleBLL;
        public PeopleController(IPeopleBLL ipeopleBLL)
        {
            this.ipeopleBLL = ipeopleBLL;
        }
        // GET: api/People
        [HttpGet("GetAllPeople")]
        public IActionResult GetAllPeople()
        {
            return Ok(ipeopleBLL.GetAllPeople());
        }

        // GET: api/People
        [HttpGet("GetDistinctAreaCode")]
        public IActionResult GetDistinctAreaCode()
        {
            var l = ipeopleBLL.GetDistinctAreaCode();
            return Ok(l);
        }
        // GET: api/People/5
        [HttpGet("GetPersonByPhone/{phone}")]
        public IActionResult GetPersonByPhone(string phone)
        {
            return Ok(ipeopleBLL.GetPersonByPhone(phone));
        }
        // GET: api/People/5
        [HttpGet("GetHighestCode")]
        public IActionResult GetHighestCode()
        {
            return Ok(ipeopleBLL.GetHighestCode());
        }
        // GET: api/People/5
        [HttpGet("GetDistinctCity")]
        public IActionResult GetDistinctCity()
        {
            return Ok(ipeopleBLL.GetDistinctCity());
        } // GET: api/People/5
        [HttpGet("GetDistinctDavenPlace")]
        public IActionResult GetDistinctDavenPlace()
        {
            return Ok(ipeopleBLL.GetDistinctDavenPlace());
        } // GET: api/People/5
        [HttpGet("GetDistinctStudyPlace")]
        public IActionResult GetDistinctStudyPlace()
        {
            return Ok(ipeopleBLL.GetDistinctStudyPlace());
        }
        [HttpGet("GetPeopleByFatherCode/{fatherCode}")]
        public IActionResult GetPeopleByFatherCode(int fatherCode)
        {
            return Ok(ipeopleBLL.GetPeopleByFatherCode(fatherCode));
        }
        [HttpGet("GetPeopleByFatherInLawCode/{fatherInLawCode}")]
        public IActionResult GetPeopleByFatherInLawCode(int fatherInLawCode)
        {
            return Ok(ipeopleBLL.GetPeopleByFatherInLawCode(fatherInLawCode));
        }
        [HttpGet("GetPeopleByCity/{city}")]
        public IActionResult GetPeopleByCity(string city)
        {
            return Ok(ipeopleBLL.GetPeopleByCity(city));
        }
        [HttpGet("GetPeoplByEducationPlace/{educationPlace}")]
        public IActionResult GetPeoplByEducationPlace(string educationPlace)
        {
            return Ok(ipeopleBLL.GetPeopleByEducationPlace(educationPlace));
        }
        [HttpGet("GetPeopleByDavenPlace/{davenPlace}")]
        public IActionResult GetPeopleByDavenPlace(string davenPlace)
        {
            return Ok(ipeopleBLL.GetPeopleByDavenPlace(davenPlace));
        }
        [HttpGet("GetPhoneByPersonCode/{personCode}")]
        public IActionResult GetPhoneByPersonCode(int personCode)
        {
            return Ok(ipeopleBLL.GetPhoneByPersonCode(personCode));
        }
        // POST: api/People
        [HttpPost("AddPerson")]
        public IActionResult AddPerson([FromBody] PeopleDTO newP)
        {
            return Ok(ipeopleBLL.AddPerson(newP));
        }

        // PUT: api/People/5
        [HttpPut("UpdatePerson/{code}")]
        public IActionResult UpdatePerson(int code, [FromBody] PeopleDTO newP)
        {
            return Ok(ipeopleBLL.UpdatePerson(newP,code));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
