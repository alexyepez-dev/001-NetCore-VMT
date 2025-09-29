using _001_VMT.Shared.ExceptionFilter;
using Microsoft.AspNetCore.Mvc;

namespace _001_VMT.Api.Controllers
{
    [ApiController]
    [Route("api/v1/excep")]
    [TypeFilter(typeof(ExceptionManager))]
    public class ExceptionController : ControllerBase
    {
        [HttpGet("test-exception")]
        public ActionResult TestException()
        {
            throw new Exception("¡Este es un error de prueba!");
        }
    }
}