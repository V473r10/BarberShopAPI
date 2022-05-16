using Microsoft.AspNetCore.Mvc;

namespace BarberShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        [HttpPost]
        [Route("Client")]
        public IActionResult CreateClient(string Name, string Phone, string Email)
        {
            return Ok(Methods.Clients.CreateClient(Name, Phone, Email));
        }
    }
}
