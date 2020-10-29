using System.Web.Http;
using University.API.Controllers;
using University.BL.DTOs;

namespace University.Web.Controllers
{
    /// <summary>
    /// Metodo encargado de realizar la autenticación 
    /// </summary>
    /// <param name="loginDTO"></param>
    /// <returns></returns>

    [AllowAnonymous]
    public class AccountController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //demo
            bool isCredentialValid = (loginDTO.Password == "123456");
            if (!isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.Username);
                return Ok(token);
            }

            else
                return Unauthorized(); // status code 401
        }

    }
}
