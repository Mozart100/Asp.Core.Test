using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCore.Dto;
using TestCore.Dto.Poco;
using TestCore.Model;

namespace TestCore.Controllers
{
    [Route("[controller]")]
    public class SchoolController : Controller
    {
        private SchoolContext _context;
        private IDtoMapper _dtoMapper;

        public SchoolController(SchoolContext context, IDtoMapper dtoMapper)
        {
            _context = context;
            _dtoMapper = dtoMapper;
        }


        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<StudentDto> GetStudents()
        {
            var students = _context.Students.ToList();

            var dtos = _dtoMapper.ConvertToStudentDtos(students);
            return dtos;
        }

        [HttpGet("[action]/{id}")]
        public IEnumerable<StudentDto> GetStudent([FromRoute] int id)
        {
            var students = _context.Students.FirstOrDefault(x => x.ID == id);

            var dtos = _dtoMapper.ConvertToStudentDtos(new List<Student> { students });
            return dtos;
        }

        [HttpGet("stam/{cusId}/doc/{orderId}")]
        //[HttpGet("[action]/{id}")]
        public string RoutMethod(int cusId, int orderId)
        {
            return "RoutMethod";
        }


        [HttpGet("GetMethod/{id}/{name}")]
        //[HttpGet("[action]/{id}")]
        public IActionResult GetMethod(int id, string name)
        {
            return Ok("GetMethod");
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
