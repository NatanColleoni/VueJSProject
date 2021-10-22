using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        public TeachersController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{TeacherId}")]
        public IActionResult Get(int TeacherId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{TeacherId}")]
        public IActionResult Put(int TeacherId)
        {
            return Ok();
        }

        [HttpDelete("{TeacherId}")]
        public IActionResult Delete(int TeacherId)
        {
            return Ok();
        }
    }
}
