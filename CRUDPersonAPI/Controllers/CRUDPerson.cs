using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CRUDPersonAPI.Repository;

namespace CRUDPersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDPerson : ControllerBase
    {
        [HttpGet]
        [Route("Person")]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(new PersonRepository().GetAll());
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
