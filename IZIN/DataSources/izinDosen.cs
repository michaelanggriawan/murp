using System;
using System.Collections.Generic;
using System.Data;
using MURP.Core;

namespace MURP.DataSources
{
    public sealed class izinDosen : Core.Base.DataSource<Models.izinDosen>
    {
        internal static IEnumerable<DataRow> Rows;

        public izinDosen() => TableName = "izindosen";

        public override void Load()
        {
            if (DGTable == null)
            {
                return;
            }

            string queryString = "SELECT * FROM izindosen INNER JOIN dosen ON izindosen.kdDosen = dosen.kdDosen";
            Db.OpenConn();
            var izinDosen = Db.ExecuteQuery(queryString);

            Collection.Clear();

            foreach (DataRow Row in izinDosen.Rows)
            {
                Collection.Add(new Models.izinDosen()
                {
                    izindosen = Convert.ToInt32(Row["izinDosen"]),
                    kdDosen = Row["kdDosen"].ToString(),
                    nmDosen = Row["nmDosen"].ToString(),
                    jamPengajuanIzin = Row["jamPengajuanIzin"].ToString(),
                    tglPengajuanIzin = Row["tglPengajuanIzin"].ToString(),
                    alasanIzin = Row["alasanIzin"].ToString()
                });

            }
        }




        public override bool Add(Models.izinDosen dosen)
        {
            Db.OpenConn();
            var data = new Dictionary<string, object>();
            data.Add("kdDosen", dosen.kdDosen);
            data.Add("idKelas", dosen.idKelas);
            data.Add("idSemester", dosen.idSemester);
            data.Add("kdProdi", dosen.kdProdi);
            data.Add("kdMataKuliah", dosen.kdMataKuliah);
            data.Add("tglPengajuanIzin", System.DateTime.Parse(dosen.tglPengajuanIzin).ToString("dd.MM.yyyy"));
            data.Add("jamPengajuanIzin", dosen.jamPengajuanIzin);
            data.Add("alasanIzin", dosen.alasanIzin);
            Load();
            Db.Insert("izindosen", data);

            return true;

        }

        public override void Update(Models.izinDosen t)
        {
            var Data = new Dictionary<string, object>();
            Data.Add("nmDosen", t.nmDosen);
            Data.Add("tanggalIzin", t.tglPengajuanIzin);
            Data.Add("alasanIzin", t.alasanIzin);
            Db.Update(TableName, new KeyValuePair<string, string>("kdDosen", t.kdDosen), Data);
        }

        public override void Delete(Models.izinDosen t)
        {
            Db.Delete(TableName, t.kdDosen, "kdDosen");
            Collection.Remove(t);
        }



    }
}
