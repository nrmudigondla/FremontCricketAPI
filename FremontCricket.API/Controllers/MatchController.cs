using FremontCricket.Data;
using FremontCricket.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FremontCricket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                MatchDAL matchDAL = new MatchDAL();

                var result = matchDAL.GetAllMatches();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error getting all matches");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]Match match)
        {
            try
            {
                if (match == null)
                    return BadRequest();

                MatchDAL matchDAL = new MatchDAL();

                var result = matchDAL.AddMatch(match);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new match record");
            }
        }
    }
}
