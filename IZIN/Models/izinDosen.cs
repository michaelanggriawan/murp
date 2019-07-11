using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MURP.Models
{
    public class izinDosen : Core.Base.Model
    {
        public int izindosen { get; set; }
        public string kdDosen { get; set; }
        public string nmDosen { get; set; }
        public int idSemester { get; set; }
        public int idKelas { get; set; }
        public string kdProdi { get; set; }
        public string kdMataKuliah { get; set; }
        public string tglPengajuanIzin { get; set; }
        public string jamPengajuanIzin { get; set; }
        public string alasanIzin { get; set; }
        public bool isChecked { get; set; }
        public string status { get; set; }

    }
}
