using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MURP.Models;

namespace MURP.DataSources
{
    public sealed class Dosen : Core.Base.DataSource<Models.Dosen>
    {
        public override bool Add(Models.Dosen t)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Models.Dosen t)
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            DataTable dt = Core.Db.ExecuteQuery("SELECT * FROM dosen");
            Collection.Clear();
            foreach (DataRow rows in dt.Rows)
            {
                Collection.Add(new Models.Dosen()
                {
                    kdDosen = rows["kdDosen"].ToString(),
                    nmDosen = rows["nmDosen"].ToString()
                });
            }
        }

        public override void Update(Models.Dosen t)
        {
            throw new NotImplementedException();
        }
    }
}
