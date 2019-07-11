using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MURP.Models;

namespace MURP.DataSources
{
    public sealed class Prodi : Core.Base.DataSource<Models.Prodi>
    {
        public override bool Add(Models.Prodi t)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Models.Prodi t)
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            var dt = Core.Db.ExecuteQuery("SELECT * FROM prodi");
            Collection.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Collection.Add(new Models.Prodi()
                {
                    kdProdi = row["kdProdi"].ToString(),
                    prodi = row["prodi"].ToString()
                });
            }
        }

        public override void Update(Models.Prodi t)
        {
            throw new NotImplementedException();
        }
    }
}
