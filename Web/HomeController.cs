namespace Web
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Post(RequestModel request)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}