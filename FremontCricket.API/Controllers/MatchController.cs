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
