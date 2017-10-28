using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MAInstructor.Models;
using System.Linq;

namespace MAInstructor.Controllers
{
  [Route("api/[controller]")]
  public class InstructorController : Controller
  {
    private readonly InstructorContext _context;

    public InstructorController(InstructorContext context)
    {
      _context = context;

      if(_context.Instructors.Count() == 0)
      {
        _context.Instructors.Add(new Instructor { Name = "Jim Nietzell"});
        _context.SaveChanges();
      }
    }

    [HttpGet]
    public IEnumerable<Instructor> GetAll()
    {
      return _context.Instructors.ToList();
    }

    [HttpGet("{id}", Name="GetInstructor")]
    public IActionResult GetById(long id)
    {
      var instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);
      if(instructor == null)
      {
        return NotFound();
      }
      return new ObjectResult(instructor);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Instructor instructor)
    {
      if (instructor == null)
      {
        return BadRequest();
      }

      _context.Instructors.Add(instructor);
      _context.SaveChanges();

      return CreatedAtRoute("GetInstructor", new { id = instructor.Id }, instructor);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Instructor instructor)
    {
      if (instructor == null || instructor.Id != id)
      {
        return BadRequest();
      }

      var updateInstructor = _context.Instructors.FirstOrDefault(s => s.Id == id);
      if (updateInstructor == null)
      {
        return NotFound();
      }

      updateInstructor.Name = instructor.Name;
      updateInstructor.Rank = instructor.Rank;

      _context.Instructors.Update(updateInstructor);
      _context.SaveChanges();
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var instructor = _context.Instructors.FirstOrDefault(s => s.Id == id);
      if (instructor == null)
      {
        return NotFound();
      }

      _context.Instructors.Remove(instructor);
      _context.SaveChanges();
      return new NoContentResult();
    }
  }
}