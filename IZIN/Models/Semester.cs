using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MURP.Models
{
    public class Semester : Core.Base.Model
    {
        public int idSemester { get; set; }
        public string semester { get; set; }
        public string thnAkademik { get; set; }
    }
}
