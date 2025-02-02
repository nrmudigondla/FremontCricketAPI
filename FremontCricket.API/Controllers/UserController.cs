using FremontCricket.Data;
using FremontCricket.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FremontCricket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                UserDAL userDAL = new UserDAL();

                var result = userDAL.AddUser(user);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }
    }
}
