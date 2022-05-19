using Microsoft.AspNetCore.Mvc;
using BarberShopAPI.Methods;

namespace BarberShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : Controller
    {
        [HttpGet]
        [Route("Dates")]
        public JsonResult GetDates()
        {
            return Json(Dates.GetDates());
        }

        [HttpGet]
        [Route("Date")]
        public JsonResult GetDate(int Id)
        {
            return Json(Dates.GetDate(Id));
        }

        [HttpPost]
        [Route("Dates")]
        public IActionResult CreateDate(int IdCliente, int Service, string Day, string Hour, string ExtraServices = "")
        {
            return Ok(Dates.CreateDate(IdCliente, Service, Day, Hour, ExtraServices));        
        }

        [HttpPut]
        [Route("Dates")]
        public IActionResult UpdateDate(int Id, string Day, string Hour)
        {
            return Ok(Dates.UpdateDate(Id, Day, Hour));
        }

        [HttpDelete]
        [Route("Dates")]
        public IActionResult DeleteDate(int Id)
        {
            return Ok(Dates.DeleteDate(Id));
        }
        
    }
}
