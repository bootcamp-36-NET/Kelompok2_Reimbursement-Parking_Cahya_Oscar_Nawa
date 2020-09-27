using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReimbursementParkingClient.Controllers
{
    [Route("/Error/{status}")]
    public class ErrorHandler : Controller
    {
        public IActionResult HttpStatusCodeHandler(int status)
        {
            if (status == 404)
            {
                ViewBag.msg = "We could not find the page you were looking for.";
            }
            return View("ErrorHandler");
        }
    }
}
