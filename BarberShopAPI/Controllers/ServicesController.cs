using Microsoft.AspNetCore.Mvc;
using BarberShopAPI.Data;
using System.Text.Json;

namespace BarberShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        [HttpGet]
        [Route("Services")]
        //public IActionResult GetServices()
        public JsonResult GetServices()
        {
            //return Json(Services.GetServices());
            return Json(Services.GetServices());
        }

        [HttpPost]
        [Route("Services")]
        public IActionResult AddService(string Name, string Price)
        {
            return Ok(Services.AddService(Name, Price));
        }
    }
}
