using Microsoft.AspNetCore.Mvc;

namespace BarberShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : Controller
    {
        [HttpPost]
        [Route("Date")]
        public IActionResult CreateDate(int IdCliente, int Service, string Day, string Hour, string ExtraServices = "")
        {
            return Ok(Methods.Dates.CreateDate(IdCliente, Service, Day, Hour, ExtraServices));
        }
        
    }
}
