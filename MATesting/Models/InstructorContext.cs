using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MAInstructor.Models
{
    public class InstructorContext : DbContext
    {
        public InstructorContext(DbContextOptions<InstructorContext> options)
            : base(options)
        {

        }

        public DbSet<Instructor> Instructors { get; set; }
    }
}
