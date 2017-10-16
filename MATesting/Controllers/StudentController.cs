using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MATesting.Models;
using System.Linq;

namespace MATesting.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;

            if(_context.Students.Count() == 0)
            {
                _context.Students.Add(new Student { Name = "Andrew Rady" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(long id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            return new ObjectResult(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Student student)
        {
            if(student == null || student.Id != id)
            {
                return BadRequest();
            }

            var updateStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            if(updateStudent == null)
            {
                return NotFound();
            }

            updateStudent.Name = student.Name;
            updateStudent.Rank = student.Rank;
            
            _context.Students.Update(updateStudent);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if(student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return new NoContentResult();
        }
        
    }
}