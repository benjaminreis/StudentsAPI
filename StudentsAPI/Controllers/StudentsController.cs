using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        internal Managers.StudentsManager StudentsManager = new Managers.StudentsManager();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(StudentsManager.GetStudents());
        }
    }
}
