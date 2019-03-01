using Microsoft.AspNetCore.Mvc;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("{id}", Name = "Get")]
        public int Get(int id)
        {
            return id;
        }
    }
}
