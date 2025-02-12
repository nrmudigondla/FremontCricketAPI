using FremontCricket.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FremontCricket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]Guid Id)
        {
            try
            {
                PlayerDAL playerDAL = new PlayerDAL();

                var result = playerDAL.GetPlayersByTeam(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error getting player information");
            }
        }
    }
}
