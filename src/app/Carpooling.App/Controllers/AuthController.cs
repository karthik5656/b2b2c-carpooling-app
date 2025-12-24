using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carpooling.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("AuthController is working!");
        }
    }
}
