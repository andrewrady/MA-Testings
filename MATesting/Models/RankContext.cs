using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MARank.Models
{
  public class RankContext : DbContext
  {
    public RankContext(DbContextOptions<RankContext> options)
      : base(options)
    {

    }

    public DbSet<Rank> Ranks { get; set; }
  }
}
