using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return Ok("This is blog Index Action Method");
        }
        public IActionResult Article()
        {
            return Ok("This is Article Action Method");
        }

        public IActionResult BlogDetails()
        {
            return Ok("This is Blog Details Action Method");
        }
    }
}
