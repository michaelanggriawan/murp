using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MURP.Models;

namespace MURP.DataSources
{
    public sealed class MataKuliah : Core.Base.DataSource<Models.MataKuliah>
    {
        public MataKuliah()
        {
            TableName = "matakuliah";
        }
        public override void Load()
        {
            Core.Db.OpenConn();
            var dt = Core.Db.ExecuteQuery("SELECT * FROM " + TableName);

            Collection.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Collection.Add(new Models.MataKuliah()
                {
                    kdMataKuliah = row["kdMataKuliah"].ToString(),
                    mataKuliah = row["mataKuliah"].ToString()
                });
            }
        }

        public override bool Add(Models.MataKuliah t)
        {
            var data = new Dictionary<string, object>();
            data.Add("kdMatakuliah", t.kdMataKuliah);
            data.Add("mataKuliah", t.mataKuliah);

            Core.Db.Insert(TableName, data);
            return true;
        }

        public override void Update(Models.MataKuliah t)
        {
            var data = new Dictionary<string, object>();
            data.Add("mataKuliah", t.mataKuliah);

            Core.Db.Update(TableName, new KeyValuePair<string, string>("kdMataKuliah", t.kdMataKuliah), data);
        }

        public override void Delete(Models.MataKuliah t)
        {
            Core.Db.Delete(TableName, t.kdMataKuliah, "kdMataKuliah");
            Collection.Remove(t);
        }
    }
}
