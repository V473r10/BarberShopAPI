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
        public JsonResult GetServices()
        {
            return Json(Services.GetServices());
        }

        [HttpPost]
        [Route("Services")]
        public IActionResult AddService(string Name, string Price)
        {
            return Ok(Services.AddService(Name, Price));
        }

        [HttpPut]
        [Route("Services/Name")]
        public IActionResult UpdateName(int Id, string Name)
        {
            return Ok(Services.UpdateName(Id, Name));
        }

        [HttpPut]
        [Route("Services/Price")]
        public IActionResult UpdatePrice(int Id, int Price)
        {
            return Ok(Services.UpdatePrice(Id, Price));
        }
        [HttpDelete]
        [Route("Services")]
        public IActionResult DeleteService(int Id)
        {
            return Ok(Services.DeleteService(Id));
        }
    }
}
