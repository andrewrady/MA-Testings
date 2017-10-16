using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MATesting.Models
{
    public class Student
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Rank { get; set; }
        public String Judge { get; set; }  
        public int FormScore { get; set; }
        public int WeaponScore { get; set; }
        public int SparringScore { get; set; }
        public int BoardBreakScore { get; set; }
        public int FitTestScore { get; set; }

    }
}
