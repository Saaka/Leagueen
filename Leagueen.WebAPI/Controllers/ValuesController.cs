using Microsoft.AspNetCore.Mvc;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        [HttpGet("{id}", Name = "Get")]
        public int Get(int id)
        {
            return id;
        }
    }
}
