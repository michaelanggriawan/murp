using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MURP.Models;

namespace MURP.DataSources
{
    public sealed class Semester : Core.Base.DataSource<Models.Semester>
    {
        public override bool Add(Models.Semester t)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Models.Semester t)
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            var dt = Core.Db.ExecuteQuery("SELECT * FROM semester");
            Collection.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Collection.Add(new Models.Semester()
                {
                    idSemester = Convert.ToInt32(row["idSemester"]),
                    semester = row["semester"].ToString(),
                    thnAkademik = row["thnAkademik"].ToString()
                });
            }
        }

        public override void Update(Models.Semester t)
        {
            throw new NotImplementedException();
        }
    }
}
