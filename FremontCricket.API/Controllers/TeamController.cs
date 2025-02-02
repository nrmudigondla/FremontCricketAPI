using FremontCricket.Data;
using FremontCricket.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FremontCricket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                TeamDAL teamDAL = new TeamDAL();

                var result = teamDAL.GetAllTeams();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new team record");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Team team)
        {
            try
            {
                if (team == null)
                    return BadRequest();

                TeamDAL teamDAL = new TeamDAL();

                var result = teamDAL.AddTeam(team);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new team record");
            }
        }
    }
}
