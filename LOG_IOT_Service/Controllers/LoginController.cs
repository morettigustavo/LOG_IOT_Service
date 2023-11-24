using LOG_IOT_Service.Models_DbContext;
using LOG_IOT_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace LOG_IOT_Service.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(USER _User)
        {
            DbContext dbContext = new DbContext();

            var user = dbContext.USER.FirstOrDefault(p => p.USERNAME == _User.USERNAME && p.PASSWORD == _User.PASSWORD);
            if (user == null)
            {
                return NotFound(new {message = "User not found"});
            }
            else
            {
                var token = TokenService.GenerateToken(user);

                _User.PASSWORD = "";
                return new
                {
                    user = _User,
                    token = token,
                };
            }
        }
    }
}
