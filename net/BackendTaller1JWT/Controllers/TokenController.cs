using BackendTaller1.Interfaces;
using BackendTaller1.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTaller1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IJwt _jwt;

        public TokenController(IJwt jwt)
        {
            _jwt = jwt;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] DTOAuthInfo item)
        {
            string token = string.Empty;

            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error en las propiedades del modelo de datos");
                }

                token = _jwt.Authenticate(item.username, item.password);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(token);
        }

    }
}
