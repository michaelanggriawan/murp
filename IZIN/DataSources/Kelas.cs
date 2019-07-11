using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MURP.Models;
using MURP.Core;

namespace MURP.DataSources
{
    public sealed class Kelas : Core.Base.DataSource<Models.Kelas>
    {
        public Kelas()
        {
            TableName = "kelas";
        }
        public override void Load()
        {
            Core.Db.OpenConn();

            Collection.Clear();

            DataTable dt = Core.Db.ExecuteQuery("SELECT * FROM kelas");
            foreach (DataRow row in dt.Rows)
            {
                Collection.Add(new Models.Kelas()
                {
                    idKelas = Convert.ToInt32(row["idKelas"]),
                    kelas = row["kelas"].ToString()
                });
            }
        }

        public override bool Add(Models.Kelas grade)
        {


            return true;
        }

        public override void Delete(Models.Kelas kelas)
        {
            Core.Db.Delete(TableName, kelas.idKelas.ToString(), "idKelas");
            Collection.Remove(kelas);
        }

        public override void Update(Models.Kelas kelas)
        {
            var k = new Dictionary<string, object>();
            k.Add("kelas", kelas.kelas);

            var t = new KeyValuePair<string, string>("idKelas", kelas.idKelas.ToString());

            Core.Db.Update(TableName, t, k);
        }


    }
}
