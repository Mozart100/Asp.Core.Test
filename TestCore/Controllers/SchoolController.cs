using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCore.Model;

namespace TestCore.Controllers
{
    [Route("[controller]")]
    public class SchoolController : Controller
    {
        private SchoolContext _context;

        public SchoolController(SchoolContext context)
        {
            int x = 0;
            _context = context;
        }


        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<Student> GetStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
