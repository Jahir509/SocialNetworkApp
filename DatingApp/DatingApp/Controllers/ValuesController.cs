using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        

        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _context.Values.ToList();
            return Ok(values);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var value = _context.Values.FirstOrDefault(c=>c.Id==id);
            return Ok(value);
        }
    }
}
