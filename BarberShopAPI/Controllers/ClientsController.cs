using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarberShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        [HttpGet]
        [Route("Clients")]
        public JsonResult GetClient()
        {
            return Json(Methods.Clients.GetClients());
        }

        [HttpGet]
        [Route("Client")]
        public JsonResult GetClientById(int Id)
        {
            return Json(Methods.Clients.GetClientById(Id));
        }

        [HttpPost]
        [Route("Client")]
        public IActionResult CreateClient(string Name, string Phone, string Email)
        {
            return Ok(Methods.Clients.CreateClient(Name, Phone, Email));
        }

        [HttpPut]
        [Route("Client")]
        public IActionResult UpdateClient(int Id, string Name, string Phone, string Email)
        {
            return Ok(Methods.Clients.UpdateClient(Id, Name, Phone, Email));
        }

        [HttpPut]
        [Route("UpgradeClient")]
        public IActionResult UpgradeClient(int Id)
        {
            return Ok(Methods.Clients.UpgradeClient(Id));
        }

        [HttpDelete]
        [Route("Client")]
        public IActionResult DeleteClient(int Id)
        {
            return Ok(Methods.Clients.DeleteClient(Id));
        }
    }
}
