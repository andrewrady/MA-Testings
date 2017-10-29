using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MARank.Models;
using System.Linq;

namespace MARank.Controllers
{
  [Route("api/[controller]")]
  public class RankController : Controller
  {
    private readonly RankContext _context;

    public RankController(RankContext context)
    {
      _context = context;

      if(_context.Ranks.Count() == 0)
      {
        _context.Ranks.Add(new Rank { Name = "White"});
        _context.SaveChanges();
      }
    }

    [HttpGet]
    public IEnumerable<Rank> GetAll()
    {
      return _context.Ranks.ToList();
    }

    [HttpGet("{id}", Name = "GetRank")]
    public IActionResult GetById(long id)
    {
      var rank = _context.Ranks.FirstOrDefault(r => r.Id == id);
      if(rank == null)
      {
        return NotFound();
      }
      return new ObjectResult(rank);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Rank rank)
    {
      if (rank == null)
      {
        return BadRequest();
      }

      _context.Ranks.Add(rank);
      _context.SaveChanges();

      return CreatedAtRoute("GetRanks", new { id = rank.Id}, rank);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Rank rank)
    {
      if (rank == null || rank.Id != id)
      {
        return BadRequest();
      }

      var updateRank = _context.Ranks.FirstOrDefault(r => r.Id == id);
      if (updateRank == null)
      {
        return NotFound();
      }

      updateRank.Name = rank.Name;
      updateRank.Step = rank.Step;

      _context.Ranks.Update(updateRank);
      _context.SaveChanges();
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var rank = _context.Ranks.FirstOrDefault(r => r.Id == id);
      if(rank == null)
      {
        return NotFound();
      }

      _context.Ranks.Remove(rank);
      _context.SaveChanges();
      return new NoContentResult();
    }
  }
}